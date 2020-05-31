using BooksEverywhere.Models;
using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Repositories.Base;
using BooksEverywhere.Repositories.Infra;

namespace BooksEverywhere.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        #region Constructor
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
    }
}
