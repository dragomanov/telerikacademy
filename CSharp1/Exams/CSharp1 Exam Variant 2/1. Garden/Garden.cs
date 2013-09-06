using System;
using System.Globalization;
using System.Threading;

class Garden
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double[] prices = { 0.50, 0.40, 0.25, 0.60, 0.30, 0.40 };
        double totalCosts = 0;
        int[] plantsSeeds = new int[6];
        int[] plantsArea = new int[6];
        const int totalArea = 250;
        int areaLeft = totalArea;

        for (int i = 0; i < 6; i++)
        {
            plantsSeeds[i] = int.Parse(Console.ReadLine());
            if (i < 5)
            {
                plantsArea[i] = int.Parse(Console.ReadLine());
            }
            totalCosts += plantsSeeds[i] * prices[i];
            areaLeft -= plantsArea[i];
        }

        Console.WriteLine("Total costs: {0:0.00}", totalCosts);

        if (areaLeft > 0)
        {
            Console.WriteLine("Beans area: " + areaLeft);
        }
        else if (areaLeft == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }
    }
}
