using JobPortal.Models;

namespace JobPortal.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company?> GetCompanyByName(string name);
        Task<JobOffer?> GetJobOfferByJobId(int jobId);
    }
}
