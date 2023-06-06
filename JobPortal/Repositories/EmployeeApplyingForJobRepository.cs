using JobPortal.Models;
using JobPortal.Data;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories
{
    public class EmployeeApplyingForJobRepository : GenericRepository<EmployeeApplyingForJob>, IEmployeeApplyingForJobRepository
    {
        public EmployeeApplyingForJobRepository(PortalContext context) : base(context)
        {
        }
        public async Task<EmployeeApplyingForJob?> GetByBothIds(int EmployeeId, int JobId)
        {
            return await _context.EmployeesApplyingForJobs.Where(a => a.EmployeeId == EmployeeId
            && a.JobId == JobId).FirstOrDefaultAsync();
        }
    }
}
