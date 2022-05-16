using System.ComponentModel.DataAnnotations;

namespace PathCaseAPI.Identity.DTO.Requests
{
    public class UserLoginResponse
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
