using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Repository;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories.EmployeeRepository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PortalContext context) : base(context)
        {
        }
        public async Task<Employee?> GetEmployeeByFullName(string firstName, string lastName)
        {
            if (firstName == null || lastName == null)
            {
                return null;
            }

            return await _context.Employees.Where(a => (a.FirstName).ToLower().Equals(firstName.ToLower())
            && (a.LastName).ToLower().Equals(lastName.ToLower())).FirstOrDefaultAsync();
        }
    }
}
