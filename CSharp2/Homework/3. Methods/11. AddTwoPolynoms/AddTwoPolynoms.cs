using System;

class AddTwoPolynoms
{
    static int[] SumCoeffs(int[] firstCoeffs, int[] secondCoeffs)
    {
        int[] newCoeffs = new int[firstCoeffs.Length];
        for (int i = 0; i < firstCoeffs.Length; i++)
        {
            newCoeffs[i] = firstCoeffs[i] + secondCoeffs[i];
        }
        return newCoeffs;
    }

    static int[] SubstractCoeffs(int[] firstCoeffs, int[] secondCoeffs)
    {
        int[] newCoeffs = new int[firstCoeffs.Length];
        for (int i = 0; i < firstCoeffs.Length; i++)
        {
            newCoeffs[i] = firstCoeffs[i] - secondCoeffs[i];
        }
        return newCoeffs;
    }

    static int[] MultiplyCoeffs(int[] firstCoeffs, int[] secondCoeffs)
    {
        int[] newCoeffs = new int[firstCoeffs.Length + 2];

        newCoeffs[0] = firstCoeffs[0] * secondCoeffs[0];
        newCoeffs[1] = firstCoeffs[1] * secondCoeffs[0] + firstCoeffs[0] * secondCoeffs[1];
        newCoeffs[2] = firstCoeffs[2] * secondCoeffs[0] + firstCoeffs[0] * secondCoeffs[2] + firstCoeffs[1] * secondCoeffs[1];
        newCoeffs[3] = firstCoeffs[2] * secondCoeffs[1] + firstCoeffs[1] * secondCoeffs[2];
        newCoeffs[4] = firstCoeffs[2] * secondCoeffs[2];

        return newCoeffs;
    }

    static void Main()
    {
        int[] firstCoeffs = (LoadArray());
        int[] secondCoeffs = (LoadArray());

        int[] sumCoeffs = SumCoeffs(firstCoeffs, secondCoeffs);
        int[] substract = SubstractCoeffs(firstCoeffs, secondCoeffs);
        int[] multiplication = MultiplyCoeffs(firstCoeffs, secondCoeffs);

        Print(firstCoeffs);
        Print(secondCoeffs);
        Console.Write("\nThe sum is: ");
        Print(sumCoeffs);
        Console.WriteLine("\nThe substraction is: ");
        Print(substract);
        Console.WriteLine("\nThe multiplication is: ");
        PrintMulti(multiplication);
    }

    static int counter = 0;
    static int counterPrint = 0;

    private static int[] LoadArray()
    {
        counter++;
        Console.WriteLine("Please enter the coefficients (integer numbers) of the {0} polynomial nx2 + mx + k:", counter);
        int[] array = new int[3];
        Console.Write("k = ");
        array[0] = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        array[1] = int.Parse(Console.ReadLine());
        Console.Write("n = ");
        array[2] = int.Parse(Console.ReadLine());
        return array;
    }

    private static void Print(int[] polynomToPrint)
    {
        counterPrint++;
        Console.WriteLine("Polynomial {0} is: {1}x2 + {2}x +{3}", counterPrint, polynomToPrint[2], polynomToPrint[1], polynomToPrint[0]);
    }

    private static void PrintMulti(int[] polynomToPrint)
    {
        counterPrint++;
        Console.WriteLine("Polynomial {5} is: {4}x4 + {3}x3 + {2}x2 + {1}x +{0}", polynomToPrint[0], polynomToPrint[1], polynomToPrint[2], polynomToPrint[3], polynomToPrint[4], counterPrint);
    }
}