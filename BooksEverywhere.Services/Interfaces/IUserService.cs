using BooksEverywhere.Models;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;

namespace BooksEverywhere.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Create(UserViewModel user);
        User GetByUsername(string username);
        Task<User> UpdateProfile(UserViewModel user);
    }
}
