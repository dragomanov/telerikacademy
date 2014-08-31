using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.LabyrinthFirstFoundPath
{
    class Program
    {
        static char[,] lab = new char[,]{
                                            {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                            {'*', '*', ' ', '*', ' ', '*', ' '},
                                            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                            {' ', '*', '*', '*', '*', '*', ' '},
                                            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
                                        };
        static bool[,] visited;
        static bool pathFound = false;

        static void Main(string[] args)
        {
            //generates an empty 100x100 matrix, overwriting the above declared one
            lab = new char[100, 100];
            lab[75, 75] = 'e';

            //select starting position by changing the values
            int startX = 0;
            int startY = 0;

            visited = new bool[lab.GetLength(0), lab.GetLength(1)];

            FindPath(startX, startY);
        }

        private static void FindPath(int startX, int startY)
        {
            if (pathFound)
            {
                return;          //this will make sure that no other paths will be searched                
            }
            if (CurrentCellOutOfRange(startX, startY))
            {
                return;
            }
            if (lab[startX, startY] == 'e')
            {
                PrintPath();
                pathFound = true;
                return;
            }
            if (lab[startX, startY] == '*' || visited[startX, startY])
            {
                return;
            }

            visited[startX, startY] = true;

            FindPath(startX - 1, startY);   //up
            FindPath(startX, startY + 1);   //right
            FindPath(startX + 1, startY);   //down
            FindPath(startX, startY - 1);   //left

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

        private static void PrintPath()
        {
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                for (int j = 0; j < visited.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {
                        Console.Write("X ");
                    }
                    else if (lab[i, j] == 'e')
                    {
                        Console.Write("E ");
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
