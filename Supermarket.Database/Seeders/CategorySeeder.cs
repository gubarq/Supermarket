﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Database.Entities;
using Supermarket.Database.Seeders.Interfaces;
using System.Text.Json;

namespace Supermarket.Database.Seeders
{
    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(IServiceScope scope)
        {
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var json = await File.ReadAllTextAsync($"{AppContext.BaseDirectory}/SeedData/categories.json");
            var categories = JsonSerializer.Deserialize<List<Category>>(json);

            await context.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
    }
}
