using System;

class PointInCircle
{
    static void Main()
    {
        Console.Write("Enter the X coordinate of the point: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter the Y coordinate of the point: ");
        double y = double.Parse(Console.ReadLine());

        // http://stackoverflow.com/questions/481144/equation-for-testing-if-a-point-is-inside-a-circle
        // A point lies within a circle if the lenght of the line from the center of the circle to the point is less than the radius,
        // thus if (x-center_x)^2 + (y - center_y)^2 < radius^2
        // inCircle is assigned true if the point satisfies the inequality
        bool inCircle = ((x * x + y * y) < (5 * 5)) ? true : false;
        Console.WriteLine("The point is inside the circle: " + inCircle);
    }
}
