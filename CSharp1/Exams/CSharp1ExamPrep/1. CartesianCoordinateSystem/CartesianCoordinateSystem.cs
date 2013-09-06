using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        double x;
        double.TryParse(Console.ReadLine(), out x);
        double y;
        double.TryParse(Console.ReadLine(), out y);

        byte quadrant;
        if (x == 0 && y == 0)
        {
            quadrant = 0;
        }
        else if (x == 0)
        {
            quadrant = 5;
        }
        else if (y == 0)
        {
            quadrant = 6;
        }
        else if (x > 0)
        {
            if (y > 0)
            {
                quadrant = 1;
            }
            else
            {
                quadrant = 4;
            }
        }
        else if (x < 0)
        {
            if (y > 0)
            {
                quadrant = 2;
            }
            else
            {
                quadrant = 3;
            }
        }
        else
        {
            quadrant = 255;
        }

        Console.WriteLine(quadrant);
    }
}
