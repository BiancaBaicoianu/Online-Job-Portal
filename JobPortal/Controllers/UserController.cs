using JobPortal.Services;
using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly PortalContext _portalContext;

        // dependency injection = ne aduce o instanta a clasei PortalContext
        public UserController(PortalContext portalContext)
        {
                _portalContext = portalContext;
        }
        public UserController(IUserService userContext)
        {
            _userService = userContext;
        }

        [HttpGet]
        // accesam datele din baza de date
        public async Task<IActionResult> GetUsers()
        {
            var users = await _portalContext.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("userById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute]Guid id)
        {
            var user = await _portalContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }
        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = userDto.Username,
                Email = userDto.Email,
                PasswordHash = userDto.Password
            };
            await _portalContext.Users.AddAsync(newUser);
            await _portalContext.SaveChangesAsync();
            return Ok(newUser);
        }

        public IActionResult GetByUsername(string username)
        {
            var user = _userService.GetDataMappedByUsername(username);
            return Ok(user);
        }
    }
    }
