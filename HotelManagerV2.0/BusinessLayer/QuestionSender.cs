using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class QuestionSender
    {
        public int Id { get; set; }

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

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string Address { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(10)]
        public string Zip { get; set; }
    }
}
