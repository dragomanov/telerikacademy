using System;

class IsoscelesTriangleCopyright
{
    static void Main()
    {
        char copyright = '\u00A9';
        Console.WriteLine(@"
                            ©
                            ©©
                            ©©©
                            ©©
                            ©
                            ");

        for (int i = 1; i <= 5; i++)
        {
            string numCs;
            if (i <= 3)
                numCs = new String(copyright, i);
            else
                numCs = new String(copyright, 6-i);
            Console.WriteLine(numCs);
        }
    }
}
