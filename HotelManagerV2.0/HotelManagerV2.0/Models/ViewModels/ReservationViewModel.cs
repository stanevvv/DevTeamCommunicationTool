using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagerV2._0.Models.ViewModels
{
    public class ReservationViewModel
    {
        DateTime reservationStartDate;
        DateTime reservationEndDate;

        public Room ReservedRoom { get; set; }
        
        public Client Client { get; set; }
        
        public int GuestCount { get; set; }
        
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
        
        public bool IsBreakfastIncluded { get; set; }
        
        public bool IsAllInclusive { get; set; }
        
        public double Price { get; set; }
    }
}
