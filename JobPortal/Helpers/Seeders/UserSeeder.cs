using JobPortal.Data;
using JobPortal.Models;

namespace JobPortal.Helpers.Seeders
{
    public class UserSeeder
    {
        private readonly PortalContext _portalContext;

        public UserSeeder(PortalContext portalContext)
        {
            _portalContext = portalContext;
        }
        public void SeedInitialUsers()
        {
            if (!_portalContext.Users.Any())
            {
                var user1 = new User
                {
                    UserName = "User1",
                    FirstName = "Ioana",
                    LastName = "Popescu",
                    Age = 20,
                    Email = "user1@gmail.com"
                };
                var user2 = new User
                {
                    UserName = "User2",
                    FirstName = "Maria",
                    LastName = "Ionescu",
                    Age = 27,
                    Email = "user2@gmail.com"
                };
                _portalContext.Add(user1);
                _portalContext.Add(user2);

                _portalContext.SaveChanges();
                
                /*
                var userData = System.IO.File.ReadAllText("Helpers/Seeders/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.UserName = user.UserName.ToLower();

                    _context.Users.Add(user);
                }
                */
            }
        }
    }
}
