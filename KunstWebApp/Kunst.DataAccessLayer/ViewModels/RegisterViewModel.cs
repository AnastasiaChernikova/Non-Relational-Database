using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kunst.DataAccessLayer.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NickName is required")]
        public string Nickname { get; set; }

        public string Nationality { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Artmovement is required")]
        public string ArtMovement { get; set; }

        public string Website { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Incorrect Password")]
        public string ConfirmPassword { get; set; }
    }
}
