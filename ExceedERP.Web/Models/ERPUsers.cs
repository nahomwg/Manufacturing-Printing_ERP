﻿using System.ComponentModel.DataAnnotations;

namespace ExceedERP.Web.Models
{
    public class ERPUsers
    {
        
        public string UserName { get; set; }
 
        public string Email { get; set; }
        [Required]

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone")]
        public int PhoneNo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}