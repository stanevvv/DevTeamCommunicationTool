using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    class Lettuce
    {
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Lettuce()
        {
            Price = 5;
        }
    }
}
