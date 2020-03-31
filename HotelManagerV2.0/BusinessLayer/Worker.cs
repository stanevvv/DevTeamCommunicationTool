using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Common;

namespace BusinessLayer
{
    public class Worker : IdentityUser
    {

        [Required]
        [Display(Name = "First name")]
        [MaxLength(30)]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle name")]
        [MaxLength(30)]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(30)]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Identity number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = ErrorMesseges.doesntHave10CharactersErrorMessege)]
        [Range(0, Int64.MaxValue, ErrorMessage = ErrorMesseges.containsLettersErrorMessege)]
        public string IdentityNumber { get; set; }

        DateTime dateOfAppointment;

        [Required]
        [Display(Name = "Date of Appointment")]
        public DateTime DateOfAppointment
        {
            get
            {
                return dateOfAppointment.Date;
            }
            set
            {
                dateOfAppointment = value.Date;
            }
        }

        DateTime dateOfDischarge;

        [Display(Name = "Date of Discharge")]
        public DateTime DateOfDischarge
        {
            get
            {
                return dateOfDischarge.Date;
            }
            set
            {
                dateOfDischarge = value.Date;
            }
        }
    }
}
