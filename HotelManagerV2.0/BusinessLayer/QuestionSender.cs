using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Common;

namespace BusinessLayer
{
    public class QuestionSender
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

        [StringLength(10)]
        [Range(0, Int64.MaxValue, ErrorMessage = ErrorMesseges.containsLettersErrorMessege)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(40)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string Address { get; set; }

        [MaxLength(30)]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string City { get; set; }

        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(10)]
        public string Zip { get; set; }
    }
}
