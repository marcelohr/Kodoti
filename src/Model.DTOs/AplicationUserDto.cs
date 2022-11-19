using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTOs
{
    public class AplicationUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }

    public class AplicationRegisterUserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class AplicationLoginUserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
