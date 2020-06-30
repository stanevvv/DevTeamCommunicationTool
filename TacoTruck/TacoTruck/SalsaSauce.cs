using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    class SalsaSauce
    {
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public SalsaSauce()
        {
            Price = 6;
        }
    }
}
