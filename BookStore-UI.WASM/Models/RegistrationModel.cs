using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_UI.WASM.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Too long! {0} max!", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Too long! {0} max!", MinimumLength = 6)]
        [Compare(nameof(Password), ErrorMessage = "Error comparing passwords")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
