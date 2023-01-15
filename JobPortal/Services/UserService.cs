// parte apelata de client (ex ticketing), apelata la randul sau din controller

using AutoMapper;
using JobPortal.Data;
using JobPortal.Helpers.JwtToken;
using JobPortal.Helpers.JwtUtils;
using JobPortal.Models;
using JobPortal.Models.DTOs;
using JobPortal.Repositories.UserRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BCryptNet = BCrypt.Net.BCrypt;

namespace JobPortal.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public IJwtUtils _jwtUtils;

        
        public UserService(IUserRepository userRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        private readonly PortalContext _context;

        public UserDto GetDataMappedByUsername(string Username)
        {
            User user = _userRepository.GetByUsername(Username);

            var userDtoResult = _mapper.Map<UserDto>(user);
            return userDtoResult;
        }

     
        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }
        public UserResponseDto Authenticate(UserRequestDtocs model)
        {
            var user = _userRepository.FindByUsername(model.UserName);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDto(user, jwtToken);
        }

    }

}
