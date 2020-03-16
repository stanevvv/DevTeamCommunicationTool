using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer
{
    public class Worker
    {
        DateTime dateOfAppointment;
        DateTime dateOfDischarge;

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
        [StringLength(10)]
        public string PersonalNo { get; set; }

        [Required]
        [Display(Name = "Date of appointment")]
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

        [Display(Name = "Date of discharge")]
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
