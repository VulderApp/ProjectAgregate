using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vulder.SharedKernel.Interface
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(T entity);
        Task<List<T>> ListAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}