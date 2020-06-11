using AutoMapper;
using BooksEverywhere.Models;
using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;

namespace BooksEverywhere.Services
{
    public class AuthorService : IAuthorService
    {
        #region Imports
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        #endregion

        #region Constructor
        public AuthorService(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }
        #endregion

        #region Create
        public async Task<Author> Create(AuthorViewModel author)
        {
            var map = _mapper.Map<AuthorViewModel, Author>(author);
            return await _authorRepository.Create(map);
        }
        #endregion

        #region Update
        public async Task<Author> Update(AuthorViewModel author)
        {
            var getAuthorToUpdate = await _authorRepository.Get(author.IdAuthor);
            getAuthorToUpdate.Name = author.Name;
            getAuthorToUpdate.LastName = author.LastName;
            return await _authorRepository.Create(getAuthorToUpdate);
        }
        #endregion
    }
}
