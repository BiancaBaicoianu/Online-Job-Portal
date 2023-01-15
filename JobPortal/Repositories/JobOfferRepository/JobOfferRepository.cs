using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Repository;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories.JobOfferRepository
{
    public class JobOfferRepository : GenericRepository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(PortalContext context) : base(context)
        {
        }
        public async Task<JobOffer> GetJobOfferById(Guid id)
        {
            return await _context.JobOffers.Where(a => a.JobOfferId == id).FirstOrDefaultAsync();
        }
    }
}
