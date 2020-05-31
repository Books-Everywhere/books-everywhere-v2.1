using AutoMapper;
using BooksEverywhere.Models;

namespace BooksEverywhere.ViewModels.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
