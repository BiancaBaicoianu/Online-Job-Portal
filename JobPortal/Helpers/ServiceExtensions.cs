using JobPortal.Helpers.JwtToken;
using JobPortal.Helpers.Seeders;
using JobPortal.Repositories.UserRepository;
using JobPortal.Services;

namespace JobPortal.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
        
        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<UserSeeder>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();
            return services;
        }
    }
}
