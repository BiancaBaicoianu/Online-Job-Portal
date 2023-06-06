﻿using JobPortal.Data;
using JobPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(PortalContext context) : base(context)
        {
        }
        public async Task<Company?> GetCompanyByName(string name)
        {
            return await _context.Companies.Where(a => a.CompanyName == name).FirstOrDefaultAsync();
        }
        public async Task<JobOffer?> GetJobOfferByJobId(int jobId)
        {
            return await _context.JobOffers.Where(a => a.JobId == jobId).FirstOrDefaultAsync();
        }
    }
}
