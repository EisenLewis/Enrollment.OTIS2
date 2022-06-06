using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entprog.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<bool> Exists(int id);
        Task DeleteAsync(int id);
    }
}
