using JobPortal.Models.Base;
using JobPortal.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    public class User : BaseEntity
    {
        internal readonly object UsersApplyingForJobs;

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string? PhoneNumber  { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public Role Role { get; set; }

        public ICollection<JobOffer> JobOffers { get; set; }

    }
}
