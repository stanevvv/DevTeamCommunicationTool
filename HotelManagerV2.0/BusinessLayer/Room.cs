using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Common;

namespace BusinessLayer
{
    public class Room
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Room type")]
        public RoomType RoomType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        [Display(Name = "Room number")]
        public int RoomNumber { get; set; }

        int capacity;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        public int Capacity { get => capacity; set => capacity = (int)RoomType; }

        [Required]
        public bool IsFree { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Display(Name = "Adult price")]
        public double AdultPrice { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Display(Name = "Child price")]
        public double ChildPrice { get; set; }
    }
}
