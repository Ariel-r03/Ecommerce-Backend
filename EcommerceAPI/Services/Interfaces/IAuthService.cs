using EcommerceAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateTokenString(UserLoginDTO user, List<string> roles);
        Task<UserLoggedDTO> Login(UserLoginDTO user);

        Task<bool> RegisterUser(UserRegisterDTO user,string role);
    }
}
