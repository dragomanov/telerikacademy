using System;

class FloatpointComparison
{
    static void Main()
    {
        float f1 = float.Parse(Console.ReadLine());
        float f2 = float.Parse(Console.ReadLine());
        if (f1 == f2)
            Console.WriteLine(true);
        else
            Console.WriteLine(false);
    }
}
