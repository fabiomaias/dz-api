using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotzInc.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<IReadOnlyList<T>> GetPagedReponse(int pageNumber, int maxResults);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
