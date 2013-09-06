using System;

class SevenlandNumbers
{
    static void Main()
    {
        string input7Base = Console.ReadLine();
        char[] newNum = input7Base.ToCharArray();
        byte numberSize = (byte)input7Base.Length;
        switch (input7Base)
        {
            case "6":
                Console.WriteLine("10");
                return;
            case "66":
                Console.WriteLine("100");
                return;
            case "666":
                Console.WriteLine("1000");
                return;
            default:
                break;
        }
        if (newNum[numberSize - 1] == '6')
        {
            newNum[numberSize - 1]++;
            for (int i = numberSize - 1; i >= 0; i--)
            {
                if (newNum[i] == '7')
                {
                    newNum[i] = '0';
                    newNum[i - 1]++;
                }
            }
            Console.WriteLine(newNum);
        }
        else
        {
            newNum[numberSize - 1]++;
            Console.WriteLine(newNum);
        }
    }
}
