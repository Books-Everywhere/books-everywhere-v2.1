using BooksEverywhere.Services.Interfaces;
using BooksEverywhere.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using FluentNHibernate.Utils;

namespace BooksEverywhere.Web.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        #region Imports
        private readonly IUserService _userService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
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
            var userIdentity = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(userIdentity, user.Password);
                if (result.Succeeded)
                {
                    await _userService.Create(user);
                    await _signInManager.SignInAsync(userIdentity, false);
                }
                return Ok();
            }
            catch (Exception e)
            {
                await _userManager.DeleteAsync(userIdentity);
                return BadRequest();
            }
        }
        #endregion

        #region UpdateProfile
        [HttpPost]
        [Authorize]
        [Route("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserViewModel user)
        {
            try
            {
                await _userService.UpdateProfile(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] UserViewModel model)
        {
            try
            {
                var findUserByUsername = _userManager.FindByNameAsync(model.UserName);
                if (findUserByUsername != null)
                {
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    var userIdentity = await _userManager.FindByEmailAsync(findUserByUsername.Result.Email);
                    return await GenerateJwtToken(userIdentity.Email, userIdentity);
                }
                else
                {
                    var findUserByEmail = await _userManager.FindByEmailAsync(model.UserName);
                    if (findUserByEmail != null)
                    {
                        await _signInManager.PasswordSignInAsync(findUserByEmail.UserName, model.Password, false, false);
                        var userIdentity = _userManager.Users.SingleOrDefault(r => r.Email == model.UserName);
                        return await GenerateJwtToken(model.UserName, userIdentity);
                    }
                    else { throw new ApplicationException("INVALID_LOGIN_ATTEMPT"); }
                }
            }
            catch (Exception e)
            {
                BadRequest();
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
            }
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
