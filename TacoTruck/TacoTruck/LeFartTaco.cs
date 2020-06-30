using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    static class LeFartTaco
    {
        private static Beans beans = new Beans();
        private static SalsaSauce sauce = new SalsaSauce();
        private static int price = beans.Price + sauce.Price;

        public static int Price
        {
            get { return price; }
        }


    }
}
