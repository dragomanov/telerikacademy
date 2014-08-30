using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensProblem
{
    class Program
    {
        const int BoardSize = 8;

        static int solutions = 0;
        static char[][] board = new char[BoardSize][];
        static List<string> queens = new List<string>();

        static void Main(string[] args)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                board[row] = new char[BoardSize];
                for (int col = 0; col < BoardSize; col++)
                {
                    board[row][col] = '0';
                }
            }
            PutQueens(1, 0);
        }

        static void PutQueens(int count, int row)
        {
            if (count > BoardSize)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(count + 1, row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            queens.Add("" + row + col);
            DrawQueens(1, row, col);
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            queens.Remove("" + row + col);
            DrawQueens(-1, row, col);
        }

        private static void DrawQueens(int marker, int row, int col)
        {
            for (int currRow = 0; currRow < BoardSize; currRow++)
            {
                for (int currCol = 0; currCol < BoardSize; currCol++)
                {
                    if (currRow == row)
                    {
                        board[currRow][currCol] = (char)(board[currRow][currCol] + marker);
                    }
                    else if (currCol == col)
                    {
                        board[currRow][currCol] = (char)(board[currRow][currCol] + marker);
                    }
                    else if (currRow + currCol == row + col)
                    {
                        board[currRow][currCol] = (char)(board[currRow][currCol] + marker);
                    }
                    else if (currRow - currCol == row - col)
                    {
                        board[currRow][currCol] = (char)(board[currRow][currCol] + marker);
                    }
                }
            }

            board[row][col] = marker > 0 ? '*' : '0';
        }

        private static void PrintSolution()
        {
            Console.WriteLine(new String('-', BoardSize * 4 + 1));
            for (var row = 0; row < BoardSize; row++)
            {
                Console.WriteLine("| " + String.Join(" | ", board[row]) + " |");
                Console.WriteLine(new String('-', BoardSize * 4 + 1));
            }

            solutions++;
            Console.WriteLine(solutions);
            Console.ReadLine();
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (board[row][col] != '0')
            {
                return false;
            }
            return true;
        }
    }
}
