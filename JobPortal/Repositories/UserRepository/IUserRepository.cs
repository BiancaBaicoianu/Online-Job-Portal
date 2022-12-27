
using JobPortal.Models;
using JobPortal.Repositories.GenericRepository;

namespace JobPortal.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUsername(string username);
        List<User> GetAlWithInclude();
        List<User> GetAlWithJoin();
        User GetByUsername(string username);
    }

}
