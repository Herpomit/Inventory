using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<(bool isSuccess,string message)> AddAsync(T entity);

        Task<(bool isSuccess, string message)> UpdateAsync(T entity);

        Task<(bool isSuccess, string message)> DeleteAsync(T entity);

    }
}
