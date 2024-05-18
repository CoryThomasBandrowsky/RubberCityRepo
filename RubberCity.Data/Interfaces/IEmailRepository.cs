using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Data.Interfaces
{
    public interface IEmailRepository<T> where T : class
    {
        Task Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
