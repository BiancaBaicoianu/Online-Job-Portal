using JobPortal.Models;
using JobPortal.Repository;

namespace JobPortal.Repositories.JobOfferRepository
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        Task<JobOffer> GetJobOfferById(Guid id);
    }
}
