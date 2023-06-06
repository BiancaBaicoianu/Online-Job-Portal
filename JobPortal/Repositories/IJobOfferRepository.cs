using JobPortal.Models;

namespace JobPortal.Repositories
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        Task<JobOffer> GetJobOfferById(int id);
    }
}
