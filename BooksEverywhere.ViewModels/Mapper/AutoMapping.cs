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
            CreateMap<Book, BookViewModel>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Publisher, PublisherViewModel>();
            #endregion

            #region ViewModel to Entity
            CreateMap<UserViewModel, User>();
            CreateMap<BookViewModel, Book>();
            CreateMap<AuthorViewModel, Author>();
            CreateMap<PublisherViewModel, Publisher>();
            #endregion
        }
    }
}
