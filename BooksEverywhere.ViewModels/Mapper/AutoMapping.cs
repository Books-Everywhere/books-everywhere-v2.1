using AutoMapper;
using BooksEverywhere.Models;

namespace BooksEverywhere.ViewModels.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Entity to ViewModel
            CreateMap<User, UserViewModel>();
            #endregion

            #region ViewModel to Entity
            CreateMap<UserViewModel, User>();
            #endregion
        }
    }
}
