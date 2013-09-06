/**********************************************************
 * 
 * 4. Write methods that calculate the surface of a 
 * triangle by given:
 * Side and an altitude to it; Three sides; Two sides 
 * and an angle between them. Use System.Math.
 * 
 **********************************************************/

using System;

class CalculateTriangleAreaOverloads
{
    static double GetArea(double side, double height)
    {
        return side * height / 2;
    }

    // Calculates the area using Heron's formula
    // Area = √{s (s - a)(s - b)(s - c)}; s - semiperimeter; a, b, c - sides
    static double GetArea(double a, double b, double c)
    {
        double sp = (a + b + c) / 2;
        double area = Math.Sqrt(sp * (sp - a) * (sp - b) * (sp - c));

        return area;
    }

    // Area = 1/2(b)(c) x sinA; A - angle in degree; b, c - sides
    static double GetArea(decimal a, decimal b, double angle)
    {
        return Math.Sin(Math.PI * ((angle % 180) / 180)) * (double)(a * b / 2);
    }

    static void Main()
    {
        Console.WriteLine("Enter a base and a height of a triangle to calculate it's area");
        Console.Write("Base = ");
        double baseSide = double.Parse(Console.ReadLine());
        Console.Write("Height = ");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("Area = " + GetArea(baseSide, height));

        Console.WriteLine("Enter the three sides of a triangle to calculate it's area");
        Console.Write("A = ");
        double sideA = double.Parse(Console.ReadLine());
        Console.Write("B = ");
        double sideB = double.Parse(Console.ReadLine());
        Console.Write("C = ");
        double sideC = double.Parse(Console.ReadLine());
        Console.WriteLine("Area = " + GetArea(sideA, sideB, sideC));

        Console.WriteLine("Enter two sides of a triangle and the angle between them in degrees to calculate it's area");
        Console.Write("A = ");
        decimal a = decimal.Parse(Console.ReadLine());
        Console.Write("B = ");
        decimal b = decimal.Parse(Console.ReadLine());
        Console.Write("Angle = ");
        double angle = double.Parse(Console.ReadLine());
        Console.WriteLine("Area = " + GetArea(a, b, angle));
    }
}
