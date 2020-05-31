using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksEverywhere.Models.Repositories.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IList<T>> Create(IList<T> itens);
        Task<T> Create(T item);
        Task Delete(int id);
        Task Delete(T item);
        Task Delete(IList<T> itens);
        Task<T> Get(int id);
        Task<T> Get(long id);
        Task<T> Get(Guid id);
        Task<int> Total();
        Task<IEnumerable<T>> List();
        T GetById(Guid id);
    }
}
