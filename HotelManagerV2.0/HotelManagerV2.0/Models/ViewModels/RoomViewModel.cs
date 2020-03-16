using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagerV2._0.Models.ViewModels
{
    public class RoomViewModel
    {
        public int RoomNumber { get; set; }
        
        public RoomType RoomType { get; set; }
        
        public int Capacity { get; set; }
        
        public bool IsFree { get; set; }
        
        public double AdultPrice { get; set; }

        public double ChildPrice { get; set; }
    }
}
