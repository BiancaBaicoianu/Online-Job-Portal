
using JobPortal.Models;
using JobPortal.Repository;

namespace JobPortal.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByEmailAndHashedPassword(string email, string hash);
    }
}

