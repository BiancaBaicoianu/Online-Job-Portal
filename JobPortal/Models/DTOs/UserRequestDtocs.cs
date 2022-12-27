using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models.DTOs
{
    public class UserRequestDtocs
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
