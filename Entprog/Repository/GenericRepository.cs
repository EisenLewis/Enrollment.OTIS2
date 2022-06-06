using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entprog.Repository
{
    public class GenericRepository<T>
        : IGenericRepository<T> where T : class
    {
        private readonly DbContext Context;
        public GenericRepository(DbContext context)
        {
            Context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetAsync(id);
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            T entity = await GetAsync(id);

            if (entity == null)
                return false;
            else
                return true;
        }

        public Task<List<T>> GetAllAsync()
        {
            return Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            T entity = await Context.Set<T>().FindAsync(id);

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
