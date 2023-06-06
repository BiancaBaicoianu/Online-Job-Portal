﻿using JobPortal.Services;
using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Repositories.UnitOfWork;
using JobPortal.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using IAuthenticationService = JobPortal.Services.IAuthenticationService;


namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _service;

        private readonly PortalContext _portalContext;

        // dependency injection = ne aduce o instanta a clasei PortalContext
        public UserController(IUnitOfWork unitOfWork, IAuthenticationService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }
        
        //GET all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = (await _unitOfWork.Users.GetAll()).Select(a => new UserDto(a)).ToList();
            return users;
        }
        
        // GET: api/User/email
        [HttpGet("{email}")]
        public async Task<ActionResult<UserDto>> GetUser(string email)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound("User with this email doesn't exist");
            }

            return new UserDto(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Authenticate(UserLoginDTO user)
        {
            Token? token;
            try
            {
                token = await _service.Authenticate(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> PostUser(UserRegisterDTO user)
        {
            try
            {
                var newUser = await _service.Register(user);
                await _unitOfWork.Users.Create(newUser);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        // DELETE: api/Users/id
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userInDb = await _unitOfWork.Users.GetById(id);

            if (userInDb == null)
            {
                return NotFound("User with this id doesn't exist");
            }

            await _unitOfWork.Users.Delete(userInDb);
            _unitOfWork.Save();

            return Ok();
        }
    }
}