using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vulder.SharedKernel.Interface
{
    public interface IRepository
    {
        Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task<T> GetByIdAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregateRoot;
        Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task DeleteAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
    }
}