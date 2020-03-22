using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Common;

namespace BusinessLayer
{
    public class Reservation
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Reserved room")]
        public Room ReservedRoom { get; set; }

        [Required]
        [Display(Name = "Client")]
        public Client Client { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        [Display(Name = "Guest count")]
        public int GuestCount { get; set; }

        DateTime reservationStartDate;
        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate 
        { 
            get 
            {
                return reservationStartDate;
            }
            set
            {
                reservationStartDate = value.Date;
            }
        }

        DateTime reservationEndDate;
        [Required]
        [Display(Name = "End date")]
        public DateTime EndDate
        {
            get
            {
                return reservationEndDate;
            }
            set
            {
                reservationEndDate = value.Date;
            }
        }

        [Required]
        [Display(Name = "Has breakfast")]
        public bool IsBreakfastIncluded { get; set; }

        [Required]
        [Display(Name = "Is all inclusive")]
        public bool IsAllInclusive { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
