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
        private int spoiledRow;
        private int spoiledCol;

        // Inits the gameboard with an m x n chocolate bar
        public Gameboard(int rows, int cols)
        {
            gameboard = new bool[rows, cols];
            
            // Fill gameboard with all true
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                    gameboard[row, col] = true;
            }

            // Put spoiled square in somewhere
            Random rand = new Random();
            spoiledRow = rand.Next(0, rows);
            spoiledCol = rand.Next(0, cols);
            gameboard[spoiledRow, spoiledCol] = false;
        }

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
        }

        #region Information Functions
    
        public int getColumnCount() { return gameboard.GetLength(0); }
        public int getRowCount() { return gameboard.GetLength(1); }

        public bool isGameOver()
        {
            // The game is over and the player loses if:
            //  1) They are dumb and break off a piece that has the spoiled square
            //  2) There is just the spoiled piece remaining

            // Check #1
            bool foundSpoiledSquare = false;
            for(int row = 0; row < getRowCount(); row++)
            {
                for (int col = 0; col < getColumnCount(); col++)
                {
                    if (gameboard[col, row] == false)
                        foundSpoiledSquare = true;
                }
            }

            if (!foundSpoiledSquare)
                return true;

            // Check #2
            if (getRowCount() + getColumnCount() == 2)
            {
                // Double check myself. There shouldn't be 1 square left here but it isn't spoiled
                if (gameboard[0, 0] == true)
                    throw new Exception("There is only 1 square left, and it isn't spoiled! That shouldn't happen...");

                return true;
            }

            return false;
        }

        public bool rowContainsSpoiled(int row)
        {
            bool contains = false;
            for(int col = 0; col < getColumnCount(); col++)
            {
                if (gameboard[col, row] == false)
                    contains = true;
            }

            return contains;
        }

        public bool colContainsSpoiled(int col)
        {
            bool contains = false;
            for (int row = 0; row < getRowCount(); row++)
            {
                if (gameboard[col, row] == false)
                    contains = true;
            }

            return contains;
        }
        #endregion

        #region Modifying Functions
        public void TrimRight() { TrimColumn(gameboard.GetLength(1) - 1); }
        public void TrimLeft() { TrimColumn(0); }
        public void TrimTop() { TrimRow(0); }
        public void TrimBottom() { TrimRow(gameboard.GetLength(0) - 1); }

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
