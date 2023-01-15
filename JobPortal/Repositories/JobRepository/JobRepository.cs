using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Repository;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories.JobRepository
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(PortalContext context) : base(context)
        {
        }
        public async Task<Job?> GetJobByTitle(string title)
        {
            return await _context.Jobs.FirstOrDefaultAsync(job => job.JobTitle.ToLower() == title.ToLower());
        }
    }

}
