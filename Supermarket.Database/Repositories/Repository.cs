using Microsoft.EntityFrameworkCore;
using Supermarket.Database;
using Supermarket.Database.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data.Common
{
    internal class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrUpdateAsync(T entity)
        {
            if (entity.Id == default)
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedAt = DateTime.UtcNow;
            }
            else
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);
            _context.Remove(dbEntity);

            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetQuery()
            => _context.Set<T>();

        public async Task<T> GetByIdAsync(Guid id)
            => await _context.Set<T>().FindAsync(id);
    }
}
