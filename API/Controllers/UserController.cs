using API.Models;
using BL.DTOs.UserDTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Shared.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;

        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }


        [HttpPost("register")]
        public IActionResult Register(UpsertUserDTO request)
        {
            var user = _userService.Add(request);
            return Ok(new ResponseModel { Message = "User register successfully.", Data = user });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO request)
            => Ok(new ResponseModel { Data = CreateToken(_userService.Login(request.Email, request.Password)) });

        private string CreateToken(GetUserDTO user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, ConversionHelper.ConvertTo<string>(user.Role)),
                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user)),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("JWT:SecretKey").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
