using BooksEverywhere.Models;
using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Repositories.Base;
using BooksEverywhere.Repositories.Infra;

namespace BooksEverywhere.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        #region Constructor
        public AuthorRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
    }
}
