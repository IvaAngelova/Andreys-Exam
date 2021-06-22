using System;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; }
           = Guid.NewGuid().ToString();

        [Required]
        [MinLength(DataConstants.UsernameMinLength)]
        [MaxLength(DataConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MinLength(DataConstants.PassowrdMinLength)]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
