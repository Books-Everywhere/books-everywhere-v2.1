using BooksEverywhere.Models.Repositories.Interfaces.Base;

namespace BooksEverywhere.Models.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);
    }
}
