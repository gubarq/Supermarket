using Microsoft.Extensions.DependencyInjection;

namespace Supermarket.Database.Seeders.Interfaces
{
    public interface ISeeder
    {
        Task SeedAsync(IServiceScope scope);
    }
}
