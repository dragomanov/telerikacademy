using System;

class RectangleArea
{
    static void Main()
    {
        Console.Write("Enter the width of the rectangle: ");
        int width = int.Parse(Console.ReadLine());
        Console.Write("Enter the height of the rectangle: ");
        int height = int.Parse(Console.ReadLine());
        int area = width * height;
        Console.WriteLine("The area of the rectangle is {0}", area);
    }
}