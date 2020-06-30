using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Taco Truck    version 1.0";
            Console.WindowWidth = 120;
            Console.WindowHeight = 38;

            //This cycle makes an infinite loop between the gameplay and the menu. After you win or lose, you return.
            do
            {

                //This variable answers why you lost the game by the Police.
                string outcome = "";

                //Showing Main Menu.
                GameEvents.MainMenu();

                
                //The player is being created.
                TacoPlayer player = new TacoPlayer();

                //This cycle represents the in-game days. The win condition is: Reach 20 days.
                for (int i = 1; i <= 20; i++)
                {

                    //Increments the Day variable by 1. Outputs your current status with drugs.
                    GameEvents.NextDay(player);

                    //Generate the number of customers today.
                    Random number = new Random();
                    int numberOfCustomersToday = number.Next(3, 5);

                    //Output the number of customers today.
                    Console.WriteLine("Customers today: {0} \n", numberOfCustomersToday);

                    //Boolean variable for double loop break check.
                    bool innerLoopisBroken = false;

                    //Going trough every customer today.
                    for (int j = 0; j < numberOfCustomersToday; j++)
                    {
                        //Every customer offers a taco. The taco's type is determined by the GetTacoOrder() method
                        //which is passed by a parameter.
                        player.MakeTaco(GameEvents.GetTacoOrder(), player);

                        //Checks if the player holds drugs at the moment.
                        if (!(player.HasDrugs))
                        {
                            //If he doesn't, there is a 10% chance this guy is a dealer and they will be offered to him.
                            GameEvents.DrugKeep(player);
                        }

                        //For every customer there is a chance to be a cop, which arrests you if you hold drugs.
                        //Furthermore, the customer may be a dealer and a cop under cover.
                        outcome = GameEvents.CopRaid(player);

                        //Checks if the Police caught you with drugs or they are here because of dissatisfied customers.
                        //Either way, you lose.
                        if (outcome == "drugs" || outcome == "dissatisfaction")
                        {
                            innerLoopisBroken = true;
                            break;
                        }
                    }

                    if (innerLoopisBroken)
                    {
                        break;
                    }

                    //Outputs the player's inventory .
                    Console.WriteLine(player);

                    //Everyday a new shop is made, because the prices and quantities are randomized.
                    Shop shop = new Shop();
                    //Outputs today's offers.
                    shop.ShopInfo();

                    //This variable is made so i can reference the player's money.
                    int money = player.Money;
                    shop.BuyProducts(player.Cheeses, player.Sauces, player.Lettuces, player.Beanses,
                                     ref money);
                    player.Money = money;
                }

                //Cosmetic change.
                Console.Clear();

                //Checks if the Police caught you with drugs or they are here because of dissatisfied customers.
                //Either way, you lose
                if (outcome == "drugs" || outcome == "dissatisfaction")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME OVER");
                    Console.ResetColor();

                    Console.WriteLine("Press any key to return to the menu.");
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations! You win!");
                    Console.ResetColor();   

                    Console.WriteLine("Press any key to return to the menu.");
                    Console.ReadKey();
                }

                //Cosmetic change.
                Console.Clear();

            } while (true);
        }
    }
}






