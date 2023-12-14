using Azure.Identity;
using DB.Auth;
using EcommerceAPI.Dtos;
using EcommerceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserRegisterDTO user)
        {
            if(!ValidateEmail(user))
            {
                return BadRequest("Email is not valid");
            }

            if (await _authService.RegisterUser(user))
            {
                return Ok("User registered");
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(UserLoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userData = await _authService.Login(user);

            if (userData.UserName != null)
            {
                var tokenString =  _authService.GenerateTokenString(user);
                return Ok(new {UserData = userData, Token = tokenString});
            }
            return BadRequest(userData.ResultMessage);
        }

        [NonAction]
        private bool ValidateEmail(UserRegisterDTO model)
        {
            string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(emailRegex);
            if (!re.IsMatch(model.UserName))
            {
               return false;
            }
            return true;
        }
    }
}
