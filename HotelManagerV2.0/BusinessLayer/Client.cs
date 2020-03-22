using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Client
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
    }
}
