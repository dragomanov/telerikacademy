/**********************************************************
 * 
 * 3. Write a program that prints to the console which day 
 * of the week is today. Use System.DateTime.
 * 
 **********************************************************/

using System;

class PrintCurrentDayOfWeek
{
    static void Main()
    {
        DateTime today = DateTime.Now;
        string dayOfWeek = today.DayOfWeek.ToString();
        Console.WriteLine("Today is {0}", dayOfWeek);
    }
}
