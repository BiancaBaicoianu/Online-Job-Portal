using JobPortal.Models.Base;

namespace JobPortal.Models
{
    // One to Many relationship between Company and Job
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; } = "";
        public string CompanyDescription { get; set; } = "";
        public string CompanyCity { get; set; } = "";
        public string CompanyPhone { get; set; } = "";
        public string CompanyEmail { get; set; } = "";
        public DateTime CompanyCreationDate { get; set; } = DateTime.Now;
        public ICollection<UserApplyingForJob> UsersApplyingForJobs { get; set; }

    }
}
