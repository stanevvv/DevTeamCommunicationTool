using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace HotelManagerV2._0.Models.BindingModels
{
    public class WorkerBindingModel
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
        [Display(Name = "Email")]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [StringLength(10)]
        [Range(0, Int64.MaxValue, ErrorMessage = ErrorMesseges.containsLettersErrorMessege)]
        public string PhoneNumber { get; set; }

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
    }
}
