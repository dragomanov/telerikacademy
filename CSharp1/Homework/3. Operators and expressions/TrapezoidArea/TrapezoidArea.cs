using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.Write("Enter one side of the trapezoid: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter the other side of the trapezoid: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter the height of the trapezoid: ");
        int h = int.Parse(Console.ReadLine());
        double area = (a + b) * h / 2;
        Console.WriteLine("The area of the trapezoid is: " + area);
    }
}
