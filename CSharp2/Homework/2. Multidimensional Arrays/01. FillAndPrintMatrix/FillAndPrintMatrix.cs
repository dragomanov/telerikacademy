/********************************************************
 * Write a program that fills and prints a matrix of size
 * (n, n) as shown below: (examples for n = 4)
 ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

public class FillAndPrintMatrix
{
    static void Main()
    {
        Console.Write("Enter size of matrix square matrix: ");
        int n = int.Parse(Console.ReadLine());

        PrintMatrixType(n, 'a');
        PrintMatrixType(n, 'b');
        PrintMatrixType(n, 'c');
        PrintMatrixType(n, 'd');
    }

    static void PrintMatrixType(int n, char type)
    {
        int padLen = (n * n).ToString().Length + 1;
        int[,] arrMatrixType = new int[n, n];
        int row = 0;
        int col = 0;

        switch (type)
        {
            case 'a':
                for (int i = 0; i < n * n; i++)
                {
                    row = i % n;
                    col = i / n;
                    arrMatrixType[row, col] = i + 1;
                }
                break;
            case 'b':
                for (int i = 0; i < n * n; i++)
                {
                    col = i / n;
                    if (col % 2 == 1)
                    {
                        row = n - (i % n) - 1;
                    }
                    else
                    {
                        row = i % n;
                    }
                    arrMatrixType[row, col] = i + 1;
                }
                break;
            case 'c':
                row = n - 1;
                col = 0;

                for (int i = 0; i < n * n; i++)
                {
                    arrMatrixType[row, col] = i + 1;
                    if (row == n - 1)
                    {
                        row = (col == n - 1) ? 0 : n - col - 2;
                        col = (col == n - 1) ? 1 : 0;
                    }
                    else if (col == n - 1)
                    {
                        col = n - row;
                        row = 0;
                    }
                    else
                    {
                        row++;
                        col++;
                    }
                }
                break;
            case 'd':
                string direction = "down";
                row = 0;
                col = 0;

                for (int i = 1; i <= n * n; i++)
                {
                    arrMatrixType[row, col] = i;

                    if (direction == "right")
                    {
                        if ((col + 1 != n) && (arrMatrixType[row, col + 1] == 0))
                        {
                            col++;
                        }
                        else
                        {
                            direction = "up";
                            row--;
                        }
                    }
                    else if (direction == "down")
                    {
                        if ((row + 1 != n) && (arrMatrixType[row + 1, col] == 0))
                        {
                            row++;
                        }
                        else
                        {
                            direction = "right";
                            col++;
                        }
                    }
                    else if (direction == "left")
                    {
                        if ((col > 0) && (arrMatrixType[row, col - 1] == 0))
                        {
                            col--;
                        }
                        else
                        {
                            direction = "down";
                            row++;
                        }
                    }
                    else if (direction == "up")
                    {
                        if ((row > 0) && (arrMatrixType[row - 1, col] == 0))
                        {
                            row--;
                        }
                        else
                        {
                            direction = "left";
                            col--;
                        }
                    }

                }
                break;
            default:
                break;
        }

        PrintMatrix(arrMatrixType, padLen);

        Console.WriteLine();
    }

    public static void PrintMatrix(int[,] arrMatrix, int padLen)
    {
        int rows = arrMatrix.GetLength(0);
        int cols = arrMatrix.GetLength(1);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(arrMatrix[row, col].ToString().PadLeft(padLen));
            }
            Console.WriteLine();
        }
    }
}
