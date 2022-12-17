/*
using JobPortal.Models.DTOs;
using JobPortal.Repositories.UserRepository;

namespace JobPortal.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        //private readonly PortalDbContext _context;
        //private readonly IMapper _mapper;
        
        public UserService(JobPortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }
        
    }

}
*/