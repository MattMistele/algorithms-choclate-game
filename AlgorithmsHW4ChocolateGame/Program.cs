using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHW4ChocolateGame
{
    class Program
    {
        static Gameboard chocolateBar;

        static void Main(string[] args)
        {
            chocolateBar = new Gameboard(10, 10);

            while(true)
                Update();
        }

        static void Update()
        {
            chocolateBar.printBoard();
            Console.WriteLine("Would you like to break the 'right', 'left', 'top', or 'bottom' boundry?");
            string input = Console.ReadLine();

            // The gameboard is immutable. This means that every new turn, we instantiate
            // a new gameboard from the old one. That is a safety check on myself and prevents weird
            // things from happening.
            switch(input.ToLower())
            {
                case "right":
                    chocolateBar.TrimRight();
                    break;
                case "left":
                    chocolateBar.TrimLeft();
                    break;
                case "top":
                    chocolateBar.TrimTop();
                    break;
                case "bottom":
                    chocolateBar.TrimBottom();
                    break;
                default:
                    Console.WriteLine("I'm sorry, I did not understand that.");
                    break;
            }
        }
    }
}
