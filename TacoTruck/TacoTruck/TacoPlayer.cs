using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoTruck
{
    class TacoPlayer
    {
        private int money;

        public int Money
        {
            get { return money; }
            set
            {
                //Money reset to 0, because they can not be negative.
                if (value < 0)
                {
                    money = 0;
                }
                else
                {
                    money = value;
                }
            }
        }

        //A property, which stores if the player keeps drugs at the moment.
        public bool HasDrugs { get; set; }

        //Theese lists represent the player's inventory.
        public List<Cheese> Cheeses { get; set; }
        public List<Lettuce> Lettuces { get; set; }
        public List<SalsaSauce> Sauces { get; set; }
        public List<Beans> Beanses { get; set; }

        public TacoPlayer()
        {
            Cheeses = new List<Cheese>();
            Lettuces = new List<Lettuce>();
            Sauces = new List<SalsaSauce>();
            Beanses = new List<Beans>();

            //Every game, the player starts with 6 of each ingredient.
            for (int i = 1; i <= 6; i++)
            {
                Cheeses.Add(new Cheese());
                Lettuces.Add(new Lettuce());
                Sauces.Add(new SalsaSauce());
                Beanses.Add(new Beans());
            }

            Money = 0;
            HasDrugs = false;
        }

        //A method that lets the player choose to make or not to make the taco.
        public void MakeTaco(string tacoName, TacoPlayer player)
        {
            char decision;           
                do
                {
                    Console.Write("Do you accept the order? (y/n) \nYou can also view your inventory (i): ");
                    decision = Console.ReadKey().KeyChar;

                    if (decision == 'i')
                    {
                        Console.WriteLine(player);
                    }

                    Console.WriteLine();
                }
                while (decision != 'y' && decision != 'n');

                
                //The player accepts the taco offer.
                if (decision == 'y')
                {
                    //Checks the taco type.
                    if (tacoName == "Cheese Taco")
                    {
                        //Checks if the ingredients are available in the player's inventory.
                        if (Cheeses.Count >= 1 && Lettuces.Count >= 1)
                        {
                            Console.WriteLine(new string('-', 55));

                            Console.WriteLine("1x Cheese has been removed from your inventory!");
                            Console.WriteLine("1x Lettuce has been removed from your inventory!");

                            Cheeses.RemoveAt(0);
                            Lettuces.RemoveAt(0);
                            
                            //Tha taco has been made and the payment is determined from the customers' anger.
                            if (Customer.Anger < 20)
                            {
                                Console.WriteLine("You recieved {0} coins!", CheeseTaco.Price - 3);
                                Money += CheeseTaco.Price - 3;
                            }
                            else if (Customer.Anger < 45)
                            {
                                Console.WriteLine("You recieved {0} coins!", CheeseTaco.Price - 4);
                                Money += CheeseTaco.Price - 4;
                            }
                            else
                            {
                                Console.WriteLine("You recieved {0} coins!", CheeseTaco.Price - 5);
                                Money += CheeseTaco.Price - 5;
                            }

                            Console.WriteLine(new string('-', 55));
                        }
                        //The player doesn't have the ingredients for the taco, even though he accepted the offer.
                        else
                        {
                            Console.WriteLine(new string('-', 55));

                            if (Cheeses.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Cheese!");
                            }
                            if (Lettuces.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Lettuce!");
                            }

                            //The taco is counting as it's not made and the customers' anger raises.
                            GameEvents.RaiseCustomerAnger();

                            Console.WriteLine(new string('-', 55));
                        }

                    }
                        //Checks the taco type.
                        else if (tacoName == "Le Fart Taco")
                        {
                        if (Beanses.Count >= 1 && Sauces.Count >= 1)
                        {
                            Console.WriteLine(new string('-', 55));

                            Console.WriteLine("1x Beans has been removed from your inventory!");
                            Console.WriteLine("1x Salsa Sauce has been removed from your inventory!");

                            Beanses.RemoveAt(0);
                            Sauces.RemoveAt(0);

                            if (Customer.Anger < 20)
                            {
                                Console.WriteLine("You recieved {0} coins!", LeFartTaco.Price - 3);
                                Money += LeFartTaco.Price - 3;
                            }
                            else if (Customer.Anger < 45)
                            {
                                Console.WriteLine("You recieved {0} coins!", LeFartTaco.Price - 4);
                                Money += LeFartTaco.Price - 4;
                            }
                            else
                            {
                                Console.WriteLine("You recieved {0} coins!", LeFartTaco.Price - 5);
                                Money += LeFartTaco.Price - 5;
                            }

                            Console.WriteLine(new string('-', 55));
                        }
                        else
                        {
                            Console.WriteLine(new string('-', 55));

                            if (Beanses.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Beans!");
                            }
                            if (Sauces.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Salsa Sauce!");
                            }

                            GameEvents.RaiseCustomerAnger();

                            Console.WriteLine(new string('-', 55));
                        }
                    }
                    //Checks the taco type.
                    else if (tacoName == "Simple Taco")
                    {
                        if (Sauces.Count >= 1 && Cheeses.Count >= 1 && Lettuces.Count >= 1)
                        {
                            Console.WriteLine(new string('-', 55));

                            Sauces.RemoveAt(0);
                            Cheeses.RemoveAt(0);
                            Lettuces.RemoveAt(0);

                            Console.WriteLine("1x Cheese has been removed from your inventory!");
                            Console.WriteLine("1x Salsa Sauce has been removed from your inventory!");
                            Console.WriteLine("1x Lettuce has been removed from your inventory!");


                            if (Customer.Anger < 20)
                            {
                                Console.WriteLine("You recieved {0} coins!", Simple_Taco.Price - 3);
                                Money += Simple_Taco.Price - 3;
                            }
                            else if (Customer.Anger < 45)
                            {
                                Console.WriteLine("You recieved {0} coins!", Simple_Taco.Price - 4);
                                Money += Simple_Taco.Price - 4;
                            }
                            else
                            {
                                Console.WriteLine("You recieved {0} coins!", Simple_Taco.Price - 5);
                                Money += Simple_Taco.Price - 5;
                            }

                            Console.WriteLine(new string('-', 55));
                        }
                        else
                        {
                            Console.WriteLine(new string('-', 55));

                            if (Cheeses.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Cheese!");
                            }
                            if (Sauces.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Salsa Sauce!");
                            }
                            if (Lettuces.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Lettuce!");
                            }

                            GameEvents.RaiseCustomerAnger();

                            Console.WriteLine(new string('-', 55));
                        }
                    }
                    //Checks the taco type.
                    else if (tacoName == "Everything Taco")
                    {
                        if (Sauces.Count >= 1 && Cheeses.Count >= 1 && Lettuces.Count >= 1 && Beanses.Count >= 1)
                        {
                            Console.WriteLine(new string('-', 55));

                            Sauces.RemoveAt(0);
                            Cheeses.RemoveAt(0);
                            Lettuces.RemoveAt(0);
                            Beanses.RemoveAt(0);


                            Console.WriteLine("1x Cheese has been removed from your inventory!");
                            Console.WriteLine("1x Beans has been removed from your inventory!");
                            Console.WriteLine("1x Salsa Sauce has been removed from your inventory!");
                            Console.WriteLine("1x Lettuce has been removed from your inventory!");



                            if (Customer.Anger < 20)
                            {
                                Console.WriteLine("You recieved {0} coins!", EverythingTaco.Price - 3);
                                Money += EverythingTaco.Price + 3;
                            }
                            else if (Customer.Anger < 45)
                            {
                                Console.WriteLine("You recieved {0} coins!", EverythingTaco.Price - 4);
                                Money += EverythingTaco.Price + 2;
                            }
                            else
                            {
                                Console.WriteLine("You recieved {0} coins!", EverythingTaco.Price - 5);
                                Money += EverythingTaco.Price + 1;
                            }

                            Console.WriteLine(new string('-', 55));

                        }
                        else
                        {
                            Console.WriteLine(new string('-', 55));

                            if (Cheeses.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Cheese!");
                            }
                            if (Sauces.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Salsa Sauce!");
                            }
                            if (Lettuces.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Lettuce!");
                            }
                            if (Beanses.Count == 0)
                            {
                                Console.WriteLine("You are missing 1x Beans!");
                            }

                            GameEvents.RaiseCustomerAnger();

                            Console.WriteLine(new string('-', 55));
                        }
                    }
                }
                //The player refuses the order.
                else if (decision == 'n')
                {
                    //The customers' anger raises.
                    GameEvents.RaiseCustomerAnger();
                }
                //The player has has pressed 'i' and his inventory brings up.
                else
                {
                    Console.WriteLine(player);
                }
                Console.WriteLine();

        }


        //Outputs the current player's inventory.
        public override string ToString()
        {
            return "\n" + "=====================================" + "\n" + 
                   "Ingredients in your inventory:" + "\n" +
                   "Cheese: " + Cheeses.Count + "\n" +
                   "Sauce: " + Sauces.Count + "\n" +
                   "Lettuce: " + Lettuces.Count + "\n" +
                   "Beans: " + Beanses.Count + "\n" +
                   "Your Money: " + Money + " coins" + "\n" +
                   "=====================================";
        }        
    }
}
