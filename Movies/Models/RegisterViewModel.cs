using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordCornfirm { get; set; }
    }
}