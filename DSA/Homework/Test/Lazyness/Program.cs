using System;
class Program
{
    static void Main()
    {
        //Console.SetIn(new StreamReader("../../input.txt"));
        int N = int.Parse(Console.ReadLine());
        string[] indeces = Console.ReadLine().Split(' ');
        int A = int.Parse(indeces[0]);
        int B = int.Parse(indeces[1]);
        int[] arr = new int[N];
        string[] input = Console.ReadLine().Split(' ');
        for (int i = 0; i < N; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        Array.Sort(arr, A, B - A + 1);
        Console.WriteLine(String.Join(" ", arr));
    }
}
