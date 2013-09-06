using System;
using System.Numerics;

class AddTwoNumsAsArrOfDigits
{
    static BigInteger AddTwoNums(int[] arrNum1, int[] arrNum2)
    {
        BigInteger sum = 0;
        bool firstIsBigger = arrNum1.Length > arrNum2.Length ? true : false;
        if (firstIsBigger)
        {
            for (int i = 0; i < arrNum2.Length; i++)
            {
                sum += (BigInteger)(arrNum1[i] * Math.Pow(10, i) + arrNum2[i] * Math.Pow(10, i));
            }

            for (int i = arrNum2.Length; i < arrNum1.Length; i++)
            {
                sum += (BigInteger)(arrNum1[i] * Math.Pow(10, i));
            }
        }
        else
        {
            for (int i = 0; i < arrNum1.Length; i++)
            {
                sum += (BigInteger)(arrNum1[i] * Math.Pow(10, i) + arrNum2[i] * Math.Pow(10, i));
            }

            for (int i = arrNum1.Length; i < arrNum2.Length; i++)
            {
                sum += (BigInteger)(arrNum2[i] * Math.Pow(10, i));
            }
        }

        return sum;
    }

    static void Main()
    {
        int[] arrNum1 = { 0, 1, 2, 3, 4, 5 };
        int[] arrNum2 = { 3, 2, 1 };
        Console.WriteLine("Sum of array of digits: " + AddTwoNums(arrNum1, arrNum2));
    }
}
