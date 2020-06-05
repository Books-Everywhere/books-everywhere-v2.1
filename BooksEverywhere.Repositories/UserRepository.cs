using BooksEverywhere.Models;
using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Repositories.Base;
using BooksEverywhere.Repositories.Infra;
using System.Linq;

namespace BooksEverywhere.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Constructor
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region GetByUsername
        public User GetByUsername(string username)
        {
            return base.Query<User>().FirstOrDefault(x => x.UserName == username);
        }
        #endregion
    }
}
