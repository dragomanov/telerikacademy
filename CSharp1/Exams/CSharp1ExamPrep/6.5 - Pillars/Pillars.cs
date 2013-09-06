using System;

class Pillars
{
    static void Main()
    {
        int[] nums = new int[8];
        for (int num = 0; num < 8; num++)
        {
            nums[num] = int.Parse(Console.ReadLine());
        }

        int[] fullCellsInCol = new int[8];
        int sumOfCols = 0;
        for (int col = 0; col < 8; col++)
        {
            for (int row = 0; row < 8; row++)
            {
                if ((nums[row] >> col & 1) == 1)
                {
                    fullCellsInCol[col]++;
                }
            }
            sumOfCols += fullCellsInCol[col];
        }

        int pillar = -1;
        int fullCells = 0;
        int leftSide = 0;
        int rightSide = sumOfCols;
        for (int col = 7; col >= 0; col--)
        {
            rightSide -= fullCellsInCol[col];
            if (leftSide == rightSide)
            {
                fullCells = leftSide;
                pillar = col;
                break;
            }
            leftSide += fullCellsInCol[col];
        }

        if (pillar > -1)
        {
            Console.WriteLine(pillar);
            Console.WriteLine(fullCells);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
