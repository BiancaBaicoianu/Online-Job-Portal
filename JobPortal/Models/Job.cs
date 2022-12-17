using JobPortal.Models.Base;

namespace JobPortal.Models
{
    public class Job : BaseEntity
    {
        public Guid JobId { get; set; }
        public string JobTitle { get; set; } = "";
        public string JobDescription { get; set; } = "";

        public ICollection<UserApplyingForJob> UsersApplyingForJobs { get; set; }
        public Company Company { get; set; }
        public JobOffer JobOffer { get; set; }

    }
}
