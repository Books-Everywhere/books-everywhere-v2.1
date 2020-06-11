using BooksEverywhere.Models;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;

namespace BooksEverywhere.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book> Create(BookViewModel book);
        Task<Book> Update(BookViewModel book);
    }
}
