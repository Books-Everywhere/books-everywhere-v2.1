using BooksEverywhere.Models.Repositories.Interfaces.Base;
using System;

namespace BooksEverywhere.Models.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByToken(Guid token);
    }
}
