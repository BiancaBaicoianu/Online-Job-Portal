using JobPortal.Models;

namespace JobPortal.Repositories
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<Job?> GetJobByTitle(string title);
    }
}
