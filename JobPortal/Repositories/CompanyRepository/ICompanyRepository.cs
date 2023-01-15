using JobPortal.Models;
using JobPortal.Repository;

namespace JobPortal.Repositories.CompanyRepository
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company?> GetCompanyByName(string name);
        Task<JobOffer?> GetJobOfferByJobId(Guid jobId);
    }
}
