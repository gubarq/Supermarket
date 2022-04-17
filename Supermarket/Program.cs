using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Services.ActionServices;
using Supermarket.Core.Services.ActionServices.Interfaces;
using Supermarket.Core.Services.EntityServices;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Core.Services.HostedServices;
using Supermarket.Database;
using Supermarket.Database.Entities;
using Supermarket.Database.Repositories;
using Supermarket.Database.Repositories.Interfaces;
using Supermarket.ModelBinders;
using Supermarket.Shared.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 1;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
builder.Services.AddScoped<IDtoMappingService, DtoMappingService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddHostedService<SeedingService>();

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Pages/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Areas/Shop/Views/Pages/{0}.cshtml");
});

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(FormatingConstants.DateFormat));
        options.ModelBinderProviders.Insert(2, new DoubleModelBinderProvider());
    });

builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMvc(config =>
{
    config.MapAreaRoute(
        name: "default",
        areaName: "Shop",
        template: "{controller=Home}/{action=Index}/{id?}");
    config.MapAreaRoute(
        name: "identity",
        areaName: "Identity",
        template: "Identity/{controller=Home}/{action=Index}/{id?}");
    config.MapAreaRoute(
        name: "admin",
        areaName: "Admin",
        template: "Admin/{controller=Home}/{action=Index}/{id?}");
    config.MapRoute("Api", "api/{controller}/{action}/{id?}");
});

app.MapRazorPages();

app.Run();
