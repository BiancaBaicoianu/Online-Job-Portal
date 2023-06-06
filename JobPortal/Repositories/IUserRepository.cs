using JobPortal.Models;

namespace JobPortal.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByEmailAndHashedPassword(string email, string hash);
    }
}

