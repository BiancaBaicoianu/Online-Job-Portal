//using JobPortal.Services;
using JobPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {

        public class UserController : ControllerBase
        {
            //public readonly IUserService _userService;
            /*
            public UserController(IUserService userService)
            {
                _userService = userService;
            }
            */
            private readonly PortalContext _portalContext;

            public UserController(PortalContext portalContext)
            {
                _portalContext = portalContext;
            }
            /*
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
            */
        }
    }
}
