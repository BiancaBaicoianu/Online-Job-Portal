using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class UserApplyingForJob
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}
