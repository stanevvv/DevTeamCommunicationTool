using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Common;

namespace BusinessLayer
{
    public class Client
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "First name")]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Middle name")]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Last name")]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        [Range(0, Int64.MaxValue, ErrorMessage = ErrorMesseges.containsLettersErrorMessege)]
        public string PhoneNumber { get; set; }
    }
}
