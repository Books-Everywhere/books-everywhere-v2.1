using AutoMapper;
using BooksEverywhere.Models;
using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
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

        #region Create
        public async Task<User> Create(UserViewModel user)
        {
            var map = _mapper.Map<UserViewModel, User>(user);
            return await _userRepository.Create(map);
        }
        #endregion

        #region GetByUserName
        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }
        #endregion

        #region UpdateProfile

        public async Task<User> UpdateProfile(UserViewModel user)
        {
            var getUserToUpdate = await _userRepository.Get(user.Id);
            getUserToUpdate.Name = user.Name;
            getUserToUpdate.LastName = user.LastName;
            getUserToUpdate.BirthDate = user.BirthDate;
            getUserToUpdate.Gender = user.Gender;
            return await _userRepository.Create(getUserToUpdate);
        }
        #endregion
    }
}
