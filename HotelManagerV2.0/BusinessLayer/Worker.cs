using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Worker : IdentityUser
    {
        //public long Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle name")]
        [MaxLength(30)]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Identity number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters")]
        public string IdentityNumber { get; set; }


    }
}
