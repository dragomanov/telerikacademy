using System;

class BinaryDigitsCount
{
    static void Main()
    {
        char bit = char.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        byte[] numOfBits = new byte[n];
        for (int i = 0; i < n; i++)
        {
            uint num = uint.Parse(Console.ReadLine());
            string binaryNum = Convert.ToString(num, 2);
            numOfBits[i] = (byte)(binaryNum.Split(bit).Length - 1);
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(numOfBits[i]);
        }
    }
}
