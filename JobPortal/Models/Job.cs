using JobPortal.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    [Table("Job")]
    public class Job
    {
        [Key]
        public Guid JobId { get; set; }
        public string JobTitle { get; set; } = "";
        public string JobDescription { get; set; } = "";

        public IEnumerable<EmployeeApplyingForJob> EmployeesApplyingForJobs { get; set; } = new HashSet<EmployeeApplyingForJob>();
        public Guid JobOfferId { get; set; }
        public JobOffer? JobOffer { get; set; }

    }
}
