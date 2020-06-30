using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    static class GameEvents
    {
        //Follows which day the player is on.
        private static int dayCount = 0;

        //Default value when the drugs are not accepted.
        private static int daysLeftToKeepDrugs = -1;

        public static int DaysLeftToKeepDrugs
        {
            get
            {
                return daysLeftToKeepDrugs;
            }
            set
            {
                daysLeftToKeepDrugs = value;
            }
        }

        //Rewards you {x} coins if you keep the drugs for the required days.
        public static int MoneyRewardFromDrugsKeep { get; set; }

        public static void MainMenu()
        {
            Console.WriteLine();

            //Title.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TACO TRUCK");
            Console.ResetColor();

            //Menu options.
            Console.WriteLine("1) START");
            Console.WriteLine("2) RECIPIES");
            Console.WriteLine("3) INSTRUCTIONS");
            Console.WriteLine("4) EXIT");
            Console.Write("Navigate by pressing the corresponding digit: ");

            
            char userChoice;
            do
            {
                userChoice = Console.ReadKey().KeyChar;

                if (userChoice == '4')
                {
                    Environment.Exit(0);
                }
                else if (userChoice == '2')
                {
                    TacoMenu();
                }
                else if (userChoice == '3')
                {
                    Rulebook();
                }
            } while (userChoice != '1' && userChoice != '2' && userChoice != '3' && userChoice != '4');


        }

        //A method which outputs all the tacos and the ingredients they need to be made.
        public static void TacoMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string (' ', 39) + "TACO MENU");
            Console.ResetColor();

            Console.WriteLine(new string('-',88));



            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("   Cheese Taco           ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Le Fart Taco          ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Simple Taco           ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Everything Taco           ");
            Console.ResetColor();

            Console.WriteLine("   Ingredients:          Ingredients:          Ingredients:          Ingredients:");
            Console.WriteLine("   1x Cheese             1x Salsa Sauce        1x Cheese             1x Cheese");
            Console.WriteLine("   1x Lettuce            1x Beans              1x Lettuce            1x Lettuce");
            Console.WriteLine("                                               1x Salsa Sauce        1x Salsa Sauce");
            Console.WriteLine("                                                                     1x Beans");

            Console.WriteLine(new string('-', 88));

            Console.WriteLine("Press any key to return to the main menu!");

            Console.ReadKey();
            Console.Clear();
            //Returns to main menu.
            MainMenu();
        }

        //A page with some introduction for the game.
        public static void Rulebook()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string(' ', 49) + "RULES");
            Console.ResetColor();
            Console.WriteLine(new string('-', 105));

            Console.WriteLine("In this game, you are the local taco chef. \"Feed the customers\" is your favourite " +
                              "phrase and your duty!\nFeed them or their anger will raise! When they are angry, they" +
                              " might call cops on your tail! You should\nbe very careful with them as they might" +
                              " close your precious restaurant. Oh, and one last thing, try not\nto get red handed" +
                              " by the police while storing some illegal drugs ;)");
            Console.WriteLine(new string('-', 105));

            Console.WriteLine("Press any key to return to the main menu!");

            Console.ReadKey();
            Console.Clear();
            //Returns to main menu.
            MainMenu();
        }

        //A method that determines the type of taco which the current customer offered.
        public static string GetTacoOrder()
        {
            Random number = new Random();
            //4 types of taco, 25% for each to occur.
            int tacoNameGenerator = number.Next(1, 5);

            switch(tacoNameGenerator)
            {
                case 1:
                    {
                        Console.Write("My order is ");

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("Cheese Taco");

                        Console.ResetColor();

                        return "Cheese Taco";
                    }
                case 2:
                    {
                        Console.Write("My order is ");

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Le Fart Taco");

                        Console.ResetColor();

                        return "Le Fart Taco";
                    }
                case 3:
                    {
                        Console.Write("My order is ");

                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.WriteLine("Simple Taco");

                        Console.ResetColor();

                        return "Simple Taco";
                    }
                case 4:
                    {
                        Console.Write("My order is ");

                        Console.ForegroundColor = ConsoleColor.Magenta;

                        Console.WriteLine("Everything Taco");

                        Console.ResetColor();

                        return "Everything Taco";
                    }
            }

            //This is actually never returned.
            return "";
        }

        //A method that raises the customers' anger permamently. It occurs when the offer is refused by the player or
        //it can not be made.
        public static void RaiseCustomerAnger()
        {
            Random number = new Random();
            //Randomly generated number which increments current customers' anger.
            int angerRaiser = number.Next(1, 11);

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("You didn't make the taco and the customers' anger was increased by {0}", angerRaiser);
            Customer.Anger += angerRaiser;

            //Anger < 20 = Low anger.
            if (Customer.Anger < 20)
            {
                Console.Write("Customers' anger: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Low");
                Console.ResetColor();
            }
            //Anger >= 20, Anger < 45 = Medium anger. 
            else if (Customer.Anger < 45)
            {
                Console.Write("Customers' anger: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Medium");
                Console.ResetColor();
            }
            //Anger >= 45 = High anger.
            else
            {
                Console.Write("Customers' anger: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("High");
                Console.ResetColor();
            }
            Console.WriteLine(new string('-', 70));
        }


        //A method that MAY offer the player drugs.
        public static void DrugKeep(TacoPlayer player)
        {
            Random number = new Random();
            int chanceOfDealerAppearance = number.Next(0, 101);

            //Default value when the drugs are not accepted.
            int keepDrugThatManyDays = -1;

            //10% chance of the customer being a dealer.
            if (chanceOfDealerAppearance <= 10)
            {
                Console.Write("Psst...! Do you want some easy money? All you need to do is store theese drugs in your pocket ;)\n(y/n): ");

                char decision;
                do
                { 
                    decision = Console.ReadKey().KeyChar;
                }
                while (decision != 'y' && decision != 'n');


                //The player accepts to keep the drugs.
                if (decision == 'y')
                {
                    //Now the player has drugs.
                    player.HasDrugs = true;

                    //A random number(3-5) is being assigned to the property for how many days are left to keep the drug.
                    keepDrugThatManyDays = number.Next(3,6);
                    DaysLeftToKeepDrugs = keepDrugThatManyDays;


                    //Creating a second object from the Random class to avoid same numbers.
                    Random number2 = new Random();

                    //A random number(10-25) is being assigned to the property for how many coins the player is going to get as a reward.
                    int moneyReward = number2.Next(10,26);
                    MoneyRewardFromDrugsKeep = moneyReward;

                    Console.WriteLine("\nAlright, you just have to keep it {0} days and you will be rewarded {1} coins!\n", keepDrugThatManyDays, moneyReward);    
                }    
                //The player refuses to keep the drugs.
                else
                {
                    //DaysLeftToKeepDrugs = -1, which is their default value.
                    DaysLeftToKeepDrugs = keepDrugThatManyDays;
                }
            }

            //Cosmetic change.
            Console.WriteLine("\n");
        }

        //A method that MAY end the player's game under certain circumstances.
        public static string CopRaid(TacoPlayer player)
        {
            Random number = new Random();
            int chanceOfCopRaid = number.Next(0, 101);

            //10% chance of the customer being a cop.
            if (chanceOfCopRaid <= 13)
            {
                Console.WriteLine("STOP! You are going to be searched by the Police.\n...");

                //The "\n"s at the end of the WriteLine statements are cosmetic.
                //Checks if the player holds drugs at this time.
                if (player.HasDrugs == true)
                {
                    Console.WriteLine("The Police found the drugs and your business is closed! You now have to live a new life... in jail.\n");

                    Console.ReadKey();

                    return "drugs";
                }
                //Checks if the customers' anger is Medium;
                else if (Customer.Anger >= 20 && Customer.Anger < 45)
                {
                    Console.WriteLine("The police sanctioned you for 10 coins due to customer complaints!");

                    player.Money -= 10;

                    return "complaints";
                }
                //Checks if the customers' anger is High;
                else if (Customer.Anger >= 45)
                {
                    Console.WriteLine("Your store has been shut down by the Police! Reason: Too many dissatisfied customers!\n");

                    Console.ReadKey();

                    return "dissatisfaction";
                }
                //The player is not guilty
                else
                {
                    Console.WriteLine("Nothing fishy was found by the Police. You are free for now!\n");
                }
                //The default value of the outcome variable(Main).
                return "";
            }
            //This is actually never returned.
            return "";
        }


        //A method that keeps track of which day the player is on and his drug status.
        public static void NextDay(TacoPlayer player)
        {
            dayCount++;
            Console.Clear();
            Console.Write("Day: {0}, ", dayCount);

            if (daysLeftToKeepDrugs > 0)
            {
                Console.WriteLine("You have to keep the drugs {0} more days.", daysLeftToKeepDrugs);
                DaysLeftToKeepDrugs--;
            }
            else if (daysLeftToKeepDrugs == 0)
            {
                Console.WriteLine("Congratulations! You were not caught holding drugs, so you get {0} coins!", MoneyRewardFromDrugsKeep);

                daysLeftToKeepDrugs = -1;
                player.HasDrugs = false;
                player.Money += MoneyRewardFromDrugsKeep;
            }
            else
            {
                Console.WriteLine("You do not hold any drugs at the moment!");
            }
        }

        
    }
}
