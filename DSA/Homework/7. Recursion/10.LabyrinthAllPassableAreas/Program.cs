using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.LabyrinthAllPassableAreas
{
    class Program
    {
        static char[,] lab = new char[,]{
                                            {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                            {'*', '*', ' ', '*', ' ', '*', ' '},
                                            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                            {' ', '*', '*', '*', '*', '*', ' '},
                                            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                        };
        static bool[,] visited;
        static int maxCount = 0;

        static void Main(string[] args)
        {

            visited = new bool[lab.GetLength(0), lab.GetLength(1)];

            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    if (lab[i, j] == ' ')
                    {
                        FindAllPaths(i, j, 1);
                        Console.WriteLine("Found path with length: {0}", maxCount);
                        maxCount = 0;
                        visited = new bool[lab.GetLength(0), lab.GetLength(1)];
                    }
                }
            } 
        }

        private static void FindAllPaths(int startX, int startY, int currentCount)
        {
            if (CurrentCellOutOfRange(startX, startY))
            {
                return;
            }
            if (lab[startX, startY] == '*' || visited[startX, startY])
            {
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                }
                return;
            }

            visited[startX, startY] = true;
            currentCount++;

            FindAllPaths(startX - 1, startY, currentCount);   //up
            FindAllPaths(startX, startY + 1, currentCount);   //right
            FindAllPaths(startX + 1, startY, currentCount);   //down
            FindAllPaths(startX, startY - 1, currentCount);   //left
        }

        private static bool CurrentCellOutOfRange(int startX, int startY)
        {
            if (startX < 0 || startX >= lab.GetLength(0))
            {
                return true;
            }
            if (startY < 0 || startY >= lab.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void PrintLongestPath()
        {
            Console.WriteLine("Longest connected area is {0} cells", maxCount);
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                for (int j = 0; j < visited.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
