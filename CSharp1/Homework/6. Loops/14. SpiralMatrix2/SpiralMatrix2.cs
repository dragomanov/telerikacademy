using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter matrix size: ");
        int n = int.Parse(Console.ReadLine()); ;
        int[,] matrix = new int[n, n];
        int[,] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        int curDir = 0;

        int row = 0;
        int col = 0;

        for (int i = 1; i <= n * n; i++)
        {
            matrix[row, col] = i;
            int nextRow = row + directions[curDir, 0];
            int nextCol = col + directions[curDir, 1];

            if ((0 <= nextRow) && (nextRow < n) && (0 <= nextCol) && (nextCol < n) && (matrix[nextRow, nextCol] == 0))
	        {
		         row = nextRow;
                 col = nextCol;
	        }
            else
	        {
                curDir = (curDir + 1) % 4;
	        }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadRight(4));
            }
            if (n < 20)
            {
                Console.WriteLine();
            }
        }
    }
}