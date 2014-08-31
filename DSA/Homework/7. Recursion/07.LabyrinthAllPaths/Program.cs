using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LabyrinthAllPaths
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

        static void Main(string[] args)
        {
            //select starting position by changing the values
            int startX = 0;
            int startY = 0;

            visited = new bool[lab.GetLength(0), lab.GetLength(1)];

            FindAllPaths(startX, startY);
        }

        private static void FindAllPaths(int startX, int startY)
        {
            if (CurrentCellOutOfRange(startX, startY))
            {
                return;
            }
            if (lab[startX, startY] == 'e')
            {
                PrintPath();
                return;
            }
            if (lab[startX, startY] == '*' || visited[startX, startY])
            {
                return;
            }

            visited[startX, startY] = true;

            FindAllPaths(startX - 1, startY);   //up
            FindAllPaths(startX, startY + 1);   //right
            FindAllPaths(startX + 1, startY);   //down
            FindAllPaths(startX, startY - 1);   //left

            visited[startX, startY] = false;
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
                    if (visited[i,j])
                    {
                        Console.Write("X ");
                    }
                    else if (lab[i,j] == 'e')
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
