using JobPortal.Models.DTOs;
using JobPortal.Models;
using JobPortal.Models.Enums;

namespace JobPortal.Services
{
    public interface IAuthenticationService
    {
        Task<Token?> Authenticate(UserLoginDTO? user);
        Task<User> Register(UserRegisterDTO user);
        string GenerateSalt();
        string HashPassword(string password, string salt);
        object GetById(int userId);
        //object GetById(Guid userId);
    }
}
