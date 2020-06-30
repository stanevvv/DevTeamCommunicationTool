using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    static class Customer
    {
        //Anger is a factor that influences the money customers give you and potentially the outcome of the game.
        private static int anger = 0;

        public static int Anger
        {
            get { return anger; }
            set { anger = value; }
        }



    }
}
