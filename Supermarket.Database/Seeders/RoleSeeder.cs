using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Database.Seeders.Interfaces;
using Supermarket.Database.Seeders.Models;
using System.Text.Json;

namespace Supermarket.Database.Seeders
{
    public class RoleSeeder : ISeeder
    {
        public async Task SeedAsync(IServiceScope scope)
        {
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var json = await File.ReadAllTextAsync($"{AppContext.BaseDirectory}/SeedData/roles.json");
            var roles = JsonSerializer.Deserialize<List<RoleSeedingModel>>(json);

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new()
                {
                    Name = role.Name,
                });
            }
        }
    }
}
