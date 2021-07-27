using System;
using System.Collections.Generic;

namespace Lab3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            string item;
            string removeChoice;
            string changeChoice;
            decimal changePrice;
            decimal price;
            bool keepGoing = true;
            bool removeLoop = true;
            bool addLoop = true;
            bool changeLoop = true;

            Dictionary<string, decimal> menu = new Dictionary<string, decimal>();

            menu["Salad"] = 4.99m;
            menu["pizza"] = 5.00m;
            menu["Soda"] = 1.99m;

            Console.WriteLine("Welcome to the Grand Circus Cafe!");

            while (keepGoing) 
            { 
            Console.WriteLine("\nHere is our menu!\n");

            foreach (var pair in menu)
            {
                    Console.WriteLine($"Menu Item: {pair.Key} - Price: ${pair.Value}");
            }

            Console.Write("\nWould you like to add a new menu item (A), remove a menu item (R), change a menu item (C), or quit (Q). Please enter A, R, C, or Q: ");
            choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    // Adding an item to the menu
                    case "a":
                        while (addLoop)
                        {
                            Console.Write("\nEnter the name of the item you would like to add or enter q to return to the main menu: ");
                            item = Console.ReadLine();
                            if (menu.ContainsKey(item))
                            {
                                Console.WriteLine("That item is already on the menu.");
                            }
                            else if (item == "q")
                            {
                                break;
                            }
                            else
                            {
                                Console.Write("Enter the price of that item: ");
                                price = decimal.Parse(Console.ReadLine());
                                menu[item] = price;
                                Console.WriteLine($"{item} has been added to the menu.");
                                addLoop = false;
                            }
                        }
                        break;
                    // Removing and item from the menu
                    case "r":
                        while (removeLoop)
                        {
                            Console.Write("\nEnter the name of the item you would like to remove or enter q to return to the main menu: ");
                            removeChoice = Console.ReadLine();
                            if (menu.ContainsKey(removeChoice))
                            {
                                menu.Remove(removeChoice);
                                Console.WriteLine($"{removeChoice} has been removed from the menu.");
                                removeLoop = false;
                            }
                            else if (removeChoice == "q")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That item is not on the menu.");
                            }
                        }
                        break;
                    // Changing the price of a menu item
                    case "c":
                        while (changeLoop)
                        {
                            Console.Write("\nEnter the name of the item you would like to change or enter q to return to the main menu: ");
                            changeChoice = Console.ReadLine();
                            if (changeChoice == "q")
                            {
                                break;
                            }
                            else if (menu.ContainsKey(changeChoice)) 
                            { 
                            Console.WriteLine($"The current price of {changeChoice} is {menu[changeChoice]}");
                            Console.Write("Enter the new price of the item: ");
                            changePrice = decimal.Parse(Console.ReadLine());
                            menu[changeChoice] = changePrice;
                            Console.WriteLine($"{changeChoice}'s price has been changed to {changePrice}.");
                            changeLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("\nThat item is not on the menu.");
                            }
                        }
                        break;
                    // Exits loop
                    case "q":
                        keepGoing = false;
                        break;
                    // Not a valid entry
                    default:
                        Console.WriteLine("\nThat is not a valid entry, please try again.");
                        break;
                }
            }
            Console.WriteLine("\nGoodbye!");
        }
    }
}
