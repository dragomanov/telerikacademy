using System;

class HelloName
{
    static void GreetingMsg()
    {
        string name = Console.ReadLine();
        Console.WriteLine("Hello, " + name);
    }

    static void Main()
    {
        GreetingMsg();
    }
}
