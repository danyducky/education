using Common.Validation;
using System.ComponentModel.DataAnnotations;

namespace Auth.Api.Models.Auth
{
    public class LoginModel
    {
        [Required]
        [EmailRegex]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
