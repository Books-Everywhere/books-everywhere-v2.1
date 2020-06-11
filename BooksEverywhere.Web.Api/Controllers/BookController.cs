using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BooksEverywhere.Web.Api.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : Controller
    {
        #region Imports
        private readonly IBookService _bookService;
        #endregion

        #region Constructor
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion

        #region Create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] BookViewModel book)
        {
            try
            {
                await _bookService.Create(book);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
        #endregion

        #region UpdateProfile
        [HttpPost]
        [Authorize]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] BookViewModel book)
        {
            try
            {
                await _bookService.Update(book);
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
