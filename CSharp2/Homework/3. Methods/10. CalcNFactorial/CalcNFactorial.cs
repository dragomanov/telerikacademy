using System;
using System.Numerics;
class CalcNFactorial
{
    static void MakeArray(int number)
    {
        int[] array = new int[number];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1;
        }

        BigInteger factorialN = CalculatesFactorial(array);
        Console.WriteLine(factorialN);
    }
    static BigInteger CalculatesFactorial(int[] arr)
    {
        int index = 0;
        BigInteger factorial = 1;
        for (index = 0; index < arr.Length; index++)
        {
            factorial *= arr[index];
        }
        return factorial;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        MakeArray(n);

    }
}