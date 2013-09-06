using System;
using System.Globalization;
using System.Threading;

class CoffeeMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int[] n = new int[5];
        double[] coinValue = { 0.05, 0.10, 0.20, 0.50, 1.00 };
        double traySum = 0;
        for (int i = 0; i < 5; i++)
        {
            n[i] = int.Parse(Console.ReadLine());
            traySum += n[i] * coinValue[i];
        }

        double devMoney = double.Parse(Console.ReadLine());
        double drinkPrice = double.Parse(Console.ReadLine());
        double change = devMoney - drinkPrice;

        if (change < 0)
        {
            Console.WriteLine("More {0:F2}", change * -1);
        }
        else if (traySum >= change)
        {
            Console.WriteLine("Yes {0:f2}", (traySum - change));
        } 
        else if (traySum < change)
        {
            Console.WriteLine("No {0:F2}", (change - traySum));
        }
    }
}
