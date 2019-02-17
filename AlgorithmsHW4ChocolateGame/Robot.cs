using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHW4ChocolateGame
{
    class Robot
    {
        Gameboard chocolateBar;

        public void Play(Gameboard currentGameBoard)
        {
            chocolateBar = currentGameBoard;

            bool moved = false;
            
            int[] plays = { 0, 1, 2, 3 };
            List<int> playOrder = plays.ToList();
            Shuffle(playOrder);

            foreach(int item in playOrder)
            {
                switch (item)
                {
                    case 1:
                        moved = TryBreakTop();
                        break;
                    case 2:
                        moved = TryBreakBottom();
                        break;
                    case 3:
                        moved = TryBreakLeft();
                        break;
                    case 4:
                        moved = TryBreakRight();
                        break;
                }

                if (moved)
                    return;
            }

            throw new Exception("Robot had an issue moving");
        }

        private bool TryBreakTop()
        {
            if (!chocolateBar.rowContainsSpoiled(0))
            {
                chocolateBar.TrimTop();
                Console.WriteLine("The AI broke the top.");
                return true;
            }
            return false;
        }

        private bool TryBreakBottom()
        {
            if (!chocolateBar.rowContainsSpoiled(chocolateBar.getRowCount() - 1))
            {
                chocolateBar.TrimBottom();
                Console.WriteLine("The AI broke the bottom.");
                return true;
            }
            return false;
        }

        private bool TryBreakLeft()
        {
            if (!chocolateBar.colContainsSpoiled(0))
            {
                chocolateBar.TrimLeft();
                Console.WriteLine("The AI broke the left.");
                return true;
            }
            return false;
        }

        private bool TryBreakRight()
        {
            if (!chocolateBar.colContainsSpoiled(chocolateBar.getColumnCount() - 1))
            {
                chocolateBar.TrimRight();
                Console.WriteLine("The AI broke the right.");
            }
            return false;
        }

        private static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
