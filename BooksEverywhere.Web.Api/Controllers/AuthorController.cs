using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BooksEverywhere.Web.Api.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : Controller
    {
        #region Imports
        private readonly IAuthorService _authorService;
        #endregion

        #region Constructor
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        #endregion

        #region Create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AuthorViewModel author)
        {
            try
            {
                await _authorService.Create(author);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
        #endregion

        #region Update
        [HttpPost]
        [Authorize]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] AuthorViewModel author)
        {
            try
            {
                await _authorService.Update(author);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion
    }
}
