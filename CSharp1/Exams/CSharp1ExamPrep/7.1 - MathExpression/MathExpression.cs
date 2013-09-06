using System;
using System.Globalization;
using System.Threading;

class MathExpression
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double n = double.Parse(Console.ReadLine());
        double m = double.Parse(Console.ReadLine());
        double p = double.Parse(Console.ReadLine());

        double expression = (n * n + 1 / (m * p) + 1337) / (n - 128.523123123 * p) + Math.Sin((int)m % 180);

        Console.WriteLine("{0:f6}", expression);
    }
}
