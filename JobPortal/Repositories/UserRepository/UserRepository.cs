
using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Models.Base;
using JobPortal.Repositories.GenericRepository;

namespace JobPortal.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PortalContext context) : base(context)
        {
            
        }

        public List<User> GetAlWithInclude()    // un fel de join pe o coloana
        {
            //return _table.Include(x => x.UserRoles).ToList();
            throw new NotImplementedException();
        }

        public List<User> GetAlWithJoin()
        {
            //var result = _table.Join(_context.Models2, model1.Id => model2.model1Id,(model1,model2) => new {model2,model2}).Select(obj => obj.model1 )
            throw new NotImplementedException();
        }
        public User GetByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());
        }
        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());
        }
    }

}
