using BooksEverywhere.Models;
using BooksEverywhere.ViewModels;
using System;
using System.Threading.Tasks;

namespace BooksEverywhere.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Create(UserViewModel user);
        Task Edit(User user);
        Task<User> GetById(int idUser);
        User GetByToken(Guid token);
    }
}
