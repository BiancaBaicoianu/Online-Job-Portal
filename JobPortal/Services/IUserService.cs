using JobPortal.Models;
using JobPortal.Models.DTOs;
using System.Collections.Generic;

namespace JobPortal.Services
{
    public interface IUserService
    {
        UserResponseDto Authenticate(UserRequestDtocs model);
        UserRequestDtocs GetById(Guid id);
        //Task Create(UserRequestDtocs newUser);
        UserDto GetDataMappedByUsername(string Username);
        //Task<List<User>> AllUsers { get; }

        //object? GetAllUsers();
    }
}
