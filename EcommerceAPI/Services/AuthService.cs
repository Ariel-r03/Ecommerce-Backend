using DB.Auth;
using EcommerceAPI.Dtos;
using EcommerceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        public string GenerateTokenString(UserLoginDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.UserName),
                //new Claim(ClaimTypes.Role,"Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

        public async Task<UserLoggedDTO> Login(UserLoginDTO user)
        {
            UserLoggedDTO userData;
            var identityUser = await _userManager.FindByEmailAsync(user.UserName);
            if (identityUser != null)
            {
                if (await _userManager.CheckPasswordAsync(identityUser, user.Password))
                {
                    userData = new UserLoggedDTO
                    {
                        UserId = identityUser.Id,
                        UserName = identityUser.UserName,
                        FullName = identityUser.FirstName + " " + identityUser.LastName,
                        ResultMessage = "Log in succesfully"
                    };
                    return userData;

                }
                userData = new UserLoggedDTO
                {
                    UserId = null,
                    ResultMessage = "Wrong credentials"
                };
                return userData;
            }
            userData = new UserLoggedDTO
            {
                UserId = null,
                ResultMessage = "User is not registered"
            };
            return userData;
        }

        public async Task<bool> RegisterUser(UserRegisterDTO user)
        {
            var identityUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);

            return result.Succeeded;
        }
    }


}
