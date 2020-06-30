using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    static class CheeseTaco
    {
        private static Cheese cheese = new Cheese();
        private static Lettuce lettuce = new Lettuce();
        private static int price = cheese.Price + lettuce.Price;

        public static int Price
        {
            get { return price; }
        }

    }
}
