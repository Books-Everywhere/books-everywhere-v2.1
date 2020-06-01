using BooksEverywhere.Models;
using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static BooksEverywhere.Web.Api.Controllers.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BooksEverywhere.Web.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        #region Imports
        private readonly IUserService _userService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public UserController(IUserService userService, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel user)
        {
            // cadastro funcionando, porém o retorno está estourando uma exception. verificar isso!
            var userIdentity = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email
            };
            var result = await _userManager.CreateAsync(userIdentity, user.PassWord);
            if (result.Succeeded)
            {
                await _userService.Create(user);
                await _signInManager.SignInAsync(userIdentity, false);
            }
            return Ok();
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

        #region Login
        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return await GenerateJwtToken(model.Email, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
        #endregion

        #region GenerateJwtToken
        private async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
