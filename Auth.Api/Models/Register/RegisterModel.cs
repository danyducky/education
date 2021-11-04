using Common.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Auth.Api.Models.Register
{
    public class RegisterModel
    {
        [Required]
        [EmailRegex]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
