using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Supermarket.Database;
using Supermarket.Database.Seeders;
using Supermarket.Database.Seeders.Interfaces;

namespace Supermarket.Core.Services.HostedServices
{
    public class SeedingService : IHostedService
    {
        protected IServiceProvider _serviceProvider { get; set; }
        protected List<ISeeder> seeders = new() { new RoleSeeder(), new UserSeeder(), new CategorySeeder()};

        public SeedingService(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.MigrateAsync();

            if (!await context.Roles.AnyAsync())
            {
                foreach (var seeder in seeders)
                {
                    using var seederScope = _serviceProvider.CreateScope();
                    await seeder.SeedAsync(seederScope);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
