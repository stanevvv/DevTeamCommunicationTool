using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagerV2._0.Models.ViewModels
{
    public class QuestionViewModel
    {
        public string QuestionAsked { get; set; }

        public QuestionSenderViewModel Sender { get; set; }
    }
}
