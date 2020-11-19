using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore_API.Contracts;
using BookStore_API.Data;
using BookStore_API.Mappings.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NLog;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BookStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CustomControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userInManager;
        private readonly IConfiguration _configuration;

        public UsersController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userInManager,
            IConfiguration configuration,
            ILoggerService logger,
            IMapper mapper) : base(logger, mapper)
        {
            _signInManager = signInManager;
            _userInManager = userInManager;
            _configuration = configuration;

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            LogEndpointAttempt();
            try
            {
                var user = new IdentityUser
                {
                    Email = userDto.EmailAddress,
                    UserName = userDto.EmailAddress,
                };

                var result = await _userInManager.CreateAsync(user, userDto.Password);
                if (!result.Succeeded)
                {
                    string errors = string.Join(";", result.Errors);
                    Logger.LogWarn(errors);
                    return GetInternalError(errors);
                }

                await _userInManager.AddToRoleAsync(user, SeedData.CustomerRoleName);
                return Ok(new {result.Succeeded});
            }
            catch(Exception e)
            {
                return GetInternalError(e);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            // TODO : logger
            var email = userDTO.EmailAddress;
            var password = userDTO.Password;
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result == SignInResult.Success)
            {
                var user = await _userInManager.FindByEmailAsync(email);
                var tokenString = await GenerateJSONWebToken(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized(email);
        }

        private async Task<string> GenerateJSONWebToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var roles = await _userInManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r)));

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                null,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
