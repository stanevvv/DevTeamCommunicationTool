using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    static class EverythingTaco
    {
        private static Cheese cheese = new Cheese();
        private static Lettuce lettuce = new Lettuce();
        private static SalsaSauce sauce = new SalsaSauce();
        private static Beans beans = new Beans();
        private static int price = cheese.Price + lettuce.Price + sauce.Price + beans.Price;

        public static int Price
        {
            get { return price; }
        }
    }
}
