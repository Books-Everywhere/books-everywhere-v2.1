using AutoMapper;
using BooksEverywhere.Models;
using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
using System;
using System.Threading.Tasks;

namespace BooksEverywhere.Services
{
    public class UserService : IUserService
    {
        #region Imports
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        
        #endregion

        #region Constructor
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        #endregion

        public async Task<User> Create(UserViewModel user)
        {
            var userIdentity = _mapper.Map<UserViewModel, User>(user);
            return await _userRepository.Create(userIdentity);
        }

        public Task Edit(User user)
        {
            return _userRepository.Create(user);
        }

        public Task<User> GetById(int idUser)
        {
            return _userRepository.Get(idUser);
        }

        #region GetByUserName
        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }
        #endregion
    }
}
