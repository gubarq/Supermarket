using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Database.Entities;
using Supermarket.Database.Seeders.Interfaces;
using Supermarket.Database.Seeders.Models;
using System.Text.Json;

namespace Supermarket.Database.Seeders
{
    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(IServiceScope scope)
        {
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            
            var json = await File.ReadAllTextAsync($"{AppContext.BaseDirectory}/SeedData/users.json");
            var users = JsonSerializer.Deserialize<List<UserSeedingModel>>(json);

            foreach (var user in users)
            {
                var newUser = new User()
                {
                    Email = user.Email,
                    UserName = user.Email
                };

                await userManager.CreateAsync(
                    newUser,  
                    user.Password);

                foreach (var role in user.Roles)
                {
                    await userManager.AddToRoleAsync(newUser, role);
                }
            }
        }
    }
}
