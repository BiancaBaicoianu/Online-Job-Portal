using JobPortal.Helpers.JwtToken;
using JobPortal.Services;

namespace JobPortal.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegate = nextRequestDelegate;
        }
        public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                var userId = jwtUtils.ValidateJwtToken(token);
                if (userId != Guid.Empty)
                {
                    var user = userService.GetById(userId);
                    if (user != null)
                    {
                        httpContext.Items["User"] = user;
                    }
                }
            }
            await _nextRequestDelegate(httpContext);
        }

    }
}
