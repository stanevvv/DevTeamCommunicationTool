using BusinessLayer;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagerV2._0.Models.BindingModels
{
    public class RoomBindingModel
    {
        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        public int RoomNumber { get; set; }

        [Required]
        public bool IsFree { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public double AdultPrice { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = ErrorMesseges.negativeNumberErrorMessage)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public double ChildPrice { get; set; }
    }
}
