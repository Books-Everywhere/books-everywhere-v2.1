using BooksEverywhere.Models;
using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static BooksEverywhere.Web.Api.Controllers.AccountController;

namespace BooksEverywhere.Web.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        #region Imports
        private readonly IUserService _userService;
        private readonly AccountController _accountController;
        #endregion

        #region Constructor
        public UserController(IUserService userService, AccountController accountController)
        {
            _userService = userService;
            _accountController = accountController;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel user)
        {
            var userReturn = _userService.Create(user);

            var register = new RegisterDto { Email = user.Email, Password = user.PassWord };
            await _accountController.Register(register);

            return Ok(userReturn);
        }
        #endregion

        #region Edit
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit([FromBody] User user)
        {
            _userService.Edit(user);
            return Ok();
        }
        #endregion

        #region GetById
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var useReturn = _userService.GetById(id);
            return Ok(useReturn);
        }
        #endregion
    }
}
