using JobPortal.Models.Base;
using JobPortal.Models.DTOs;
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
        private UserDto user;
        public User(UserDto user)
        {
            this.user = user;
        }

        [Key]
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string? PhoneNumber  { get; set; }
        public Role Role { get; set; } = Role.user;
        public User()
        {

        }

        public User(int employeeId, string email, string passwordHash, string passwordSalt, string phoneNumber)
        {
            this.EmployeeId = employeeId;
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.PhoneNumber = phoneNumber;
        }

        public ICollection<JobOffer> JobOffers { get; set; }

    }
}
