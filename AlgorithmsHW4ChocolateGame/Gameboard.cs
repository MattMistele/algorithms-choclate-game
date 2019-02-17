using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHW4ChocolateGame
{
    class Gameboard
    {
        // The gameboard is all true, except for a single false (the spoiled square)
        private bool[,] gameboard;

        // Inits the gameboard with an m x n chocolate bar
        public Gameboard(int m, int n)
        {
            gameboard = new bool[m, n];
            
            // Fill gameboard with all true
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                    gameboard[row, col] = true;
            }

            // Put spoiled square in somewhere
            Random rand = new Random();
            int i = rand.Next(0, m);
            int j = rand.Next(0, n);
            gameboard[i, j] = false;
        }

        public int getColumnCount() { return gameboard.GetLength(0); }
        public int getRowCount() { return gameboard.GetLength(1); }

        public void TrimRight() { TrimColumn(gameboard.GetLength(1) - 1); }
        public void TrimLeft() { TrimColumn(0); }
        public void TrimTop() { TrimRow(0); }
        public void TrimBottom() { TrimRow(gameboard.GetLength(0) - 1); }

        public void printBoard()
        {
            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                for (int col = 0; col < gameboard.GetLength(1); col++)
                {
                    // Print the spoiled square in red to make it fancyyy
                    if (!gameboard[row, col])
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(gameboard[row, col] ? " x" : " s");

                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        #region Modifying Functions

        private void TrimRow(int rowToRemove)
        {
            bool[,] result = new bool[gameboard.GetLength(0) - 1, gameboard.GetLength(1)];

            for (int i = 0, j = 0; i < gameboard.GetLength(0); i++)
            {
                if (i == rowToRemove)
                    continue;

                for (int k = 0, u = 0; k < gameboard.GetLength(1); k++)
                {
                    result[j, u] = gameboard[i, k];
                    u++;
                }
                j++;
            }

            gameboard = result;
        }

        private void TrimColumn(int columnToRemove)
        {
            bool[,] result = new bool[gameboard.GetLength(0), gameboard.GetLength(1) - 1];

            for (int i = 0, j = 0; i < gameboard.GetLength(0); i++)
            {
                for (int k = 0, u = 0; k < gameboard.GetLength(1); k++)
                {
                    if (k == columnToRemove)
                        continue;

                    result[j, u] = gameboard[i, k];
                    u++;
                }
                j++;
            }

            gameboard = result;
        }
        #endregion
    }
}
