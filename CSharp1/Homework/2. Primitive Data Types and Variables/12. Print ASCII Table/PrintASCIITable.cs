using System;

class PrintASCIITable
{
    static void Main()
    {
        for (char i = '\u0000'; i < 128; i++)
        {
            Console.WriteLine(i);
        }
    }
}
