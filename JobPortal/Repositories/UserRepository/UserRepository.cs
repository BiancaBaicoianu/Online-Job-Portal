﻿
using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Repository;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PortalContext context) : base(context) { }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.Where(a => a.Email == email).FirstOrDefaultAsync();
        }
        public async Task<User?> GetUserByEmailAndHashedPassword(string email, string hash)
        {
            return await _context.Users.Where(a => a.Email == email &&
            a.PasswordHash == hash).FirstOrDefaultAsync();
        }
    }
}
