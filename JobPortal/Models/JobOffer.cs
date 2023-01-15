using JobPortal.Models;
using JobPortal.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    [Table("JobOffer")]
    public class JobOffer
    {
        [Key]
        public Guid JobOfferId { get; set; }
        public int NoOfPositions { get; set; }
        public int MinimumSalary { get; set; }
        public string Benefits { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

    }
}

