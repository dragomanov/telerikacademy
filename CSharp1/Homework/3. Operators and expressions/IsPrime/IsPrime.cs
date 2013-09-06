using System;

class IsPrime
{
    static void Main()
    {
        Console.WriteLine("== Checks if entered number is prime ==");
        Console.Write("Enter a whole possitive number to see if it's a prime number: ");
        int number = int.Parse(Console.ReadLine());
        double maxCheck = Math.Sqrt(number);        // We only need to check for division with numbers 
                                                    // up to the square root of the specified number
        bool isPrime = true;                        // Initially we must set isPrime to True

        for (int i = 2; i <= maxCheck; i++)
        {
            if ((number % i) == 0)                  // and if the number is divisible by a number other then 1 and itself
            {
                isPrime = false;                    // we set isPrime to False
                break;                              // and stop checking if it's divisible by other numbers
            }
        }
        Console.WriteLine("The number is prime: " + isPrime); // If we didn't set isPrime to False, then it's a prime number
    }
}
