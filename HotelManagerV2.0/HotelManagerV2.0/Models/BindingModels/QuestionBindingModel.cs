using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagerV2._0.Models.BindingModels
{
    public class QuestionBindingModel
    {
        [Required]
        [MaxLength(25)]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(25)]
        [RegularExpression("^\\D*$", ErrorMessage = ErrorMesseges.containsNumbersErrorMessege)]
        public string LastName { get; set; }

        [StringLength(10)]
        [Range(0, Int64.MaxValue, ErrorMessage = ErrorMesseges.containsLettersErrorMessege)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
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

        [Required]
        [MaxLength(250)]
        public string QuestionAsked { get; set; }
    }
}
