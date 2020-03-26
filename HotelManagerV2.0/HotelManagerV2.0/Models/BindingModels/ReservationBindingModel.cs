using BusinessLayer;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagerV2._0.Models.BindingModels
{
    public class ReservationBindingModel
    {
        [Required]
        [MaxLength(10)]
        public string ReservedRoom { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        public int GuestCount { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        [Required]
        public bool IsBreakfastIncluded { get; set; }

        [Required]
        public bool IsAllInclusive { get; set; }
    }
}
