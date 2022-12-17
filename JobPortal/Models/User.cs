using JobPortal.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Models
{
    public class User : BaseEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber  { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public ICollection<JobOffer> JobOffers { get; set; }

    }
}
