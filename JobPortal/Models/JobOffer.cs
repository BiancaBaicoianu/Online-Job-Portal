using JobPortal.Models;
using JobPortal.Models.Base;
using JobPortal.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    [Table("JobOffer")]
    public class JobOffer
    {
        private JobOfferDTO job;

        public JobOffer(JobOfferDTO job)
        {
            this.job = job;
        }

        [Key]
        public int JobOfferId { get; set; }
        public int NoOfPositions { get; set; }
        public int MinimumSalary { get; set; }
        public string Benefits { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}

