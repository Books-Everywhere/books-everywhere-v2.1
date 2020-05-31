using BooksEverywhere.Models;
using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Repositories.Base;
using BooksEverywhere.Repositories.Infra;
using System;
using System.Collections.Generic;
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

        #region GetByToken
        public User GetByToken(Guid token)
        {
            return base.Query<User>().FirstOrDefault(x => x.Token == token);
        }
        #endregion
    }
}
