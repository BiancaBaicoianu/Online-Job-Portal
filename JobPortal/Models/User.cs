using JobPortal.Models.Base;
using JobPortal.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string? PhoneNumber  { get; set; }
        public Role Role { get; set; } = Role.user;
        public User()
        {

        }
        public User(Guid employeeId, string email, string passwordHash, string passwordSalt, string phoneNumber, Role role)
        {
            this.EmployeeId = employeeId;
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.PhoneNumber = phoneNumber;
            this.Role = role;
        }
        public ICollection<JobOffer> JobOffers { get; set; }

    }
}
