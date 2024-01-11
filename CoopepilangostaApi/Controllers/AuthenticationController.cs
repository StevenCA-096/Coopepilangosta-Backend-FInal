using AutoMapper;
using DataAccess.Data;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        [HttpGet("GetchangePasswordToken")]
        public string Get(string email)
        {
            return _userRepository.getChangePasswordToken(email);
        }

        [HttpGet("Login")]
        public Task<object> Login(string email,string password)
        {
            return _userRepository.Login(email,password);
        }
        [HttpGet("getLoginInfo")]

        public async Task<object> getLoginInfo(string email,string password)
        {
            return await _userRepository.getLoginInfo(email,password);
        }

        //[Authorize(Roles = "Restore")]
        [HttpPut("ChangePassword")]
        public string Get(string email,string newPassword)
        {
            return _userRepository.ChangePassword(email,newPassword);
        }

        [HttpGet("Test")]
        public string Test(string email, string newPassword)
        {
            string result = string.Empty;
            string result2 = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(newPassword);
            result = Convert.ToBase64String(encryted);
            byte[] encryted2 = System.Text.Encoding.Unicode.GetBytes(email);
            result2 = Convert.ToBase64String(encryted2);
            return result +"Result 2: "+result2;
        }
    }
}
