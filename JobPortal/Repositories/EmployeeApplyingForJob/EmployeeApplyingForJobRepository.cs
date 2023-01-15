using JobPortal.Repository;
using JobPortal.Models;
using JobPortal.Data;
using JobPortal.Repositories.EmployeeApplyingForJob;

namespace JobPortal.Repositories.EmployeeApplyingForJobRepository
{
    public class EmployeeApplyingForJobRepository : GenericRepository<EmployeeApplyingForJob>, IEmployeeApplyingForJobRepository
    {
        public EmployeeApplyingForJobRepository(PortalContext context) : base(context)
        {
        }
        public async Task<EmployeeApplyingForJob> GetEmployeeApplyingForJobByIds(Guid EmployeeId, Guid JobId)
        {
            return await _context.EmployeesApplyingForJobs
        }
    }
}
