/********************************************************
 * Write a program that reads a rectangular matrix of 
 * size N x M and finds in it the square 3 x 3 that has 
 * maximal sum of its elements.
 ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

public class MaxSumInMatrix
{
    static void Main()
    {
        int[,] matrix = new int[5, 8];
        RandPopulateMatrix(matrix);
        Console.WriteLine("Generated matrix is:");
        FillAndPrintMatrix.PrintMatrix(matrix, 2);
        Console.WriteLine();

        int bestResult = 0;
        int bestCol = 0;
        int bestRow = 0;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2] + matrix[row + 1, col + 2];
                if (currentSum > bestResult)
                {
                    bestResult = currentSum;
                    bestCol = col;
                    bestRow = row;
                }
            }
        }

        Console.WriteLine("Best platform is: ");
        Console.WriteLine("{0} {1} {2}", matrix[bestRow, bestCol], matrix[bestRow, bestCol + 1], matrix[bestRow, bestCol + 2]);
        Console.WriteLine("{0} {1} {2}", matrix[bestRow + 1, bestCol], matrix[bestRow + 1, bestCol + 1], matrix[bestRow + 1, bestCol + 2]);
        Console.WriteLine("{0} {1} {2}", matrix[bestRow + 2, bestCol], matrix[bestRow + 2, bestCol + 1], matrix[bestRow + 2, bestCol + 2]);
        Console.WriteLine("The maximum sum is: {0}", bestResult);
    }

    public static void RandPopulateMatrix(int[,] arrMatrix)
    {
        Random rng = new Random();
        int rows = arrMatrix.GetLength(0);
        int cols = arrMatrix.GetLength(1);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                arrMatrix[row, col] = rng.Next(10);
            }
        }
    }
}
