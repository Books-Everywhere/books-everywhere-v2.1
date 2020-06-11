using BooksEverywhere.Models;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;

namespace BooksEverywhere.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<Author> Create(AuthorViewModel author);
        Task<Author> Update(AuthorViewModel author);
    }
}
