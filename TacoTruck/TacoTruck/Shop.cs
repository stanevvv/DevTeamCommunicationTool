using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
     class Shop
     {
        //Variables that store the price and quantity of each product.
        private int cheesePrice;
        private int saucePrice;
        private int lettucePrice;
        private int beansPrice;
        private List<int> prices;

        private int cheeseCount;
        private int sauceCount;
        private int lettuceCount;
        private int beansCount;
        private List<int> quantities;


        //Randomiize prices and quantities.
        public Shop()
        {
            Random randomNumber = new Random();

            prices = new List<int>();

            int currentNumber;

            for (int i = 0; i < 4; i++)
            {
                //The price can vary from 4 to 8 per count.
                currentNumber = randomNumber.Next(4,9);
                prices.Add(currentNumber);
            }

            //Assigning prices
            cheesePrice = prices[0];
            saucePrice = prices[1];
            lettucePrice = prices[2];
            beansPrice = prices[3];

            quantities = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                //The quantity can vary from 1 to 4 per ingredient.
                currentNumber = randomNumber.Next(1, 5);
                quantities.Add(currentNumber);
            }

            //Assigning quantities
            cheeseCount = quantities[0];
            sauceCount = quantities[1];
            lettuceCount = quantities[2];
            beansCount = quantities[3];
        }

        //A function that outputs all of the shop's information for the current day.
        public void ShopInfo()
        {

            string info ="         WELCOME TO THE SHOP" + "\n"
                         + "=====================================" + "\n" +
                   "1) Cheese ; Price: " + cheesePrice + " ; Quantity: " + cheeseCount + "\n" +
                   "2) Sauce ; Price: " + saucePrice + " ; Quantity: " + sauceCount + "\n" +
                   "3) Lettuce ; Price: " + lettucePrice + " ; Quantity: " + lettuceCount + "\n" +
                   "4) Beans ; Price: " + beansPrice + " ; Quantity: " + beansCount + "\n" +
                   "=====================================" + "\n";
            
            Console.Write(info);
        }


        //A method that lets the player buy products from the shop.
        public void BuyProducts(List<Cheese> cheeses, List<SalsaSauce> sauces, List<Lettuce> lettuces,
                                List<Beans> beanses,  ref int playerMoney)
        {
            do
            {
                char decision;
                do
                {
                    Console.Write("Buy a product by pressing it's corresponding digit or press 'e' to exit the shop: ");
                    decision = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                } while (decision != '1' && decision != '2' && decision != '3' && decision != '4' && Char.ToUpper(decision) != 'E');



                if (Char.ToUpper(decision) == 'E')
                {
                    break;
                }


                //Checks if the player has enough money to buy the ingredient and if it's available in the store.
                if (decision == '1' && playerMoney >= cheesePrice && cheeseCount >= 1)
                {
                    cheeses.Add(new Cheese());

                    playerMoney -= cheesePrice;

                    cheeseCount--;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You bought 1x Cheese, {0} more in store", cheeseCount);
                    Console.ResetColor();                   
                }
                //Checks if the ingredient is available to output a competent message 
                else if (cheeseCount <= 0 && decision == '1')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No more Cheese is available!");
                    Console.ResetColor();
                }
                //Checks if the player has enough money to buy the selected ingredient.
                else if (decision == '1')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You don't have enough money!");
                    Console.ResetColor();
                }


                //Checks if the player has enough money to buy the ingredient and if it's available in the store.
                if (decision == '2' && playerMoney >= saucePrice && sauceCount >= 1)
                {
                    sauces.Add(new SalsaSauce());

                    playerMoney -= saucePrice;

                    sauceCount--;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You bought 1x Sauce, {0} more in store", sauceCount);
                    Console.ResetColor();
                }
                //Checks if the ingredient is available to output a competent message 
                else if (sauceCount <= 0 && decision == '2')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No more Sauce is available!");
                    Console.ResetColor();
                }
                //Checks if the player has enough money to buy the selected ingredient.
                else if (decision == '2')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You don't have enough money!");
                    Console.ResetColor();
                }


                //Checks if the player has enough money to buy the ingredient and if it's available in the store.
                if (decision == '3' && playerMoney >= lettucePrice && lettuceCount >= 1)
                {
                    lettuces.Add(new Lettuce());

                    playerMoney -= lettucePrice;

                    lettuceCount--;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You bought 1x Lettuce, {0} more in store", lettuceCount);
                    Console.ResetColor();
                }
                //Checks if the ingredient is available to output a competent message 
                else if (lettuceCount <= 0 && decision == '3')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No more Lettuce is available!");
                    Console.ResetColor();
                }
                //Checks if the player has enough money to buy the selected ingredient.
                else if (decision == '3')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You don't have enough money!");
                    Console.ResetColor();
                }


                //Checks if the player has enough money to buy the ingredient and if it's available in the store.
                if (decision == '4' && playerMoney >= beansPrice && beansCount >= 1)
                {
                    beanses.Add(new Beans());

                    playerMoney -= beansPrice;

                    beansCount--;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You bought 1x Beans, {0} more in store", beansCount);
                    Console.ResetColor();
                }
                //Checks if the ingredient is available to output a competent message 
                else if (beansCount <= 0 && decision == '4')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No more Beans is available!");
                    Console.ResetColor();
                }
                //Checks if the player has enough money to buy the selected ingredient.
                else if (decision == '4')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You don't have enough money!");
                    Console.ResetColor();
                }

            } while (true);
        }

    }
}
