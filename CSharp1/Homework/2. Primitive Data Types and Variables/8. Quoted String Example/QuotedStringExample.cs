using System;

class QuotedStringExample
{
    static void Main()
    {
        string str = "The \"use\" of quotations causes difficulties.";
        string qStr = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(str);
        Console.WriteLine(qStr);
    }
}
