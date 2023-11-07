using System;
using System.ComponentModel.DataAnnotations;

namespace URLshorter.Models
{
    public class AuthenticationRequestDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Pass { get; set; }
    }
}

