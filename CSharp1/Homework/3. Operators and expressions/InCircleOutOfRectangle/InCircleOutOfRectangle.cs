﻿using System;

class InCircleOutOfRectangle
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
        bool inCircle = (((x - 1) * (x - 1) + (y - 1) * (y - 1)) < (3 * 3)) ? true : false;

        // A point lies outside a rectangle if it's to the left of it's left side OR to right of the right side
        // OR to the top of it's top side OR to the bottom of it's bottom side
        bool outOfRectangle = (x < -1 || x > 5 || y < 1 || y > 3) ? true : false;

        // Displays true if the point is both in the circle AND outside the rectangle
        Console.WriteLine("The point is inside the circle and outside the rectangle: " + (inCircle && outOfRectangle));
    }
}
