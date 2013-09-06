/*************************************************************
 * 
 * 5. Write a program that reads a text file containing a 
 * square matrix of numbers and finds in the matrix an 
 * area of size 2 x 2 with a maximal sum of its 
 * elements. The first line in the input file contains the 
 * size of matrix N. Each of the next N lines contain N 
 * numbers separated by space. The output should be a 
 * single number in a separate text file. Example:
 * 
 * 4
 * 2 3 3 4
 * 0 2 3 4			17
 * 3 7 1 2
 * 4 3 3 2
 * 
 *************************************************************/

using System;
using System.Diagnostics;
using System.IO;

class MaxSumOfTwoByTwoMatrixFromFile
{

    static Random rng = new Random();

    static void Main()
    {
        int matSize = rng.Next(10);
        int[,] genMatrix = new int[matSize, matSize];
        RandPopulateMatrix(genMatrix);

        StreamWriter swm = new StreamWriter("input.txt");
        using (swm)
        {
            WriteMatrixToFile(genMatrix, 2, swm);
        }

        int[,] matrix;
        StreamReader sr = new StreamReader("input.txt");
        using (sr)
        {
            matrix = ReadMatrixFromFile(sr);
        }

        int bestResult = 0;
        int bestCol = 0;
        int bestRow = 0;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (currentSum > bestResult)
                {
                    bestResult = currentSum;
                    bestCol = col;
                    bestRow = row;
                }
            }
        }

        StreamWriter swr = new StreamWriter("result.txt");
        using (swr)
        {
            swr.WriteLine("The maximum sum is: {0}", bestResult);
        }

        Process.Start("input.txt");
        Process.Start("result.txt");
    }

    public static int[,] ReadMatrixFromFile(StreamReader sr)
    {
        int[,] matrix;
        int mSize = int.Parse(sr.ReadLine());
        matrix = new int[mSize, mSize];
        for (int i = 0; i < mSize; i++)
        {
            string[] line = sr.ReadLine().Split(' ');
            for (int j = 0; j < mSize; j++)
            {
                matrix[i, j] = int.Parse(line[j]);
            }
        }
        return matrix;
    }

    public static void RandPopulateMatrix(int[,] arrMatrix)
    {
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

    public static void WriteMatrixToFile(int[,] arrMatrix, int padLen, StreamWriter sw)
    {
        int rows = arrMatrix.GetLength(0);
        int cols = arrMatrix.GetLength(1);
        sw.WriteLine(rows);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                sw.Write(arrMatrix[row, col].ToString().PadRight(padLen));
            }
            sw.WriteLine();
        }
    }
}