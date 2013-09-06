using System;

class AnalyzeIntArr
{
    static void Main()
    {
        double[] arr = { 2.0, 5.0, 4.0 };
        Console.WriteLine(GetMin(arr));
        Console.WriteLine(GetMax(arr));
        Console.WriteLine(GetSum(arr));
        Console.WriteLine(GetAvg(arr));
        Console.WriteLine(GetProd(arr));
    }
    static double GetMin(double[] arr)
    {
        double min = arr[0];
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] < min)
                min = arr[i];
        return min;
    }
    static double GetMax(double[] arr)
    {
        double max = arr[0];
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] > max)
                max = arr[i];
        return max;
    }
    static double GetSum(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
            sum += arr[i];
        return sum;
    }
    static double GetAvg(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
            sum += arr[i];
        return sum / arr.Length;
    }
    static double GetProd(double[] arr)
    {
        double prod = 1;
        for (int i = 0; i < arr.Length; i++)
            prod *= arr[i];
        return prod;
    }
}