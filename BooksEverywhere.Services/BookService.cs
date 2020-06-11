using AutoMapper;
using BooksEverywhere.Models;
using BooksEverywhere.Models.Enums;
using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;

namespace BooksEverywhere.Services
{
    public class BookService : IBookService
    {
        #region Imports
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        #endregion

        #region Constructor
        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        #endregion

        #region Create
        public async Task<Book> Create(BookViewModel book)
        {
            var map = _mapper.Map<BookViewModel, Book>(book);
            return await _bookRepository.Create(map);
        }
        #endregion

        #region Update
        public async Task<Book> Update(BookViewModel book)
        {
            var getBookToUpdate = await _bookRepository.Get(book.IdBook);
            getBookToUpdate.Title = book.Title;
            getBookToUpdate.ISBN = book.ISBN;
            getBookToUpdate.Edition = book.Edition;
            getBookToUpdate.Language = book.Language;
            getBookToUpdate.PublicationDate = book.PublicationDate;
            getBookToUpdate.Author = new Author { IdAuthor = book.Author.IdAuthor };
            getBookToUpdate.Publisher = new Publisher { IdPublisher = book.Publisher.IdPublisher };
            getBookToUpdate.BookGenre = (BookGenre)book.BookGenre;
            return await _bookRepository.Create(getBookToUpdate);
        }
        #endregion
    }
}
