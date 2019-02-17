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
        static Robot robot;
        static bool playerTurn;

        static void Main(string[] args)
        {
            chocolateBar = new Gameboard(10, 10);
            robot = new Robot();

            playerTurn = true;

            GameUpdate();
        }

        static void GameUpdate()
        {
            chocolateBar.printBoard();

            if (playerTurn)
                PlayerPlay();
            else
                robot.Play(chocolateBar);

            // Check if the games over
            bool gameOver = chocolateBar.isGameOver();

            if(!gameOver)
            {
                // Make it the other player's turn, and play again!
                playerTurn = !playerTurn;
                GameUpdate();
            } else
            {
                switch (playerTurn)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Congratulations! You win! \n");
                        break;
                    case false:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Oh no! You lost! \n");
                        break;
                }
            }

        }

        static void PlayerPlay()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to break the 'right', 'left', 'top', or 'bottom' boundry?");
            string input = Console.ReadLine();

            // The gameboard is immutable. This means that every new turn, we instantiate
            // a new gameboard from the old one. That is a safety check on myself and prevents weird
            // things from happening.
            switch (input.ToLower())
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
                    PlayerPlay();
                    break;
            }
        }
    }
}
