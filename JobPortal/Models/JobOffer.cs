using JobPortal.Models;
using JobPortal.Models.Base;

namespace JobPortal.Models
{
    public class JobOffer : BaseEntity
    {
        public Guid JobOfferId { get; set; }
        public int NoOfPositions { get; set; }
        public int MinimumSalary { get; set; }
        public string Benefits { get; set; }
        public Guid JobForeignKey { get; set; }
        public Job Job { get; set; }

    }
}

