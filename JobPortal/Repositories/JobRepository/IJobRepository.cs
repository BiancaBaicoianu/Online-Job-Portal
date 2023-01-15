using JobPortal.Models;
using JobPortal.Repository;

namespace JobPortal.Repositories.JobRepository
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<Job?> GetJobByTitle(string title);
    }
}
