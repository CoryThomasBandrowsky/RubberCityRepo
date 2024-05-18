using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Data.Interfaces
{
    public interface ILocalHelpRepository<T>
    {
        Task Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
