using System;

class NullableTypesExample
{
    static void Main()
    {
        int? nullInt = null;
        double? nullDouble = null;
        nullInt += null;
        nullDouble += null;
        Console.WriteLine(nullInt);
        Console.WriteLine(nullDouble);
        nullInt += 1;
        nullDouble += 1.0;
        Console.WriteLine(nullInt);
        Console.WriteLine(nullDouble);
    }
}
