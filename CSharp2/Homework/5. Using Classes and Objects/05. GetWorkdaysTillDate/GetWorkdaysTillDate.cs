/**********************************************************
 * 
 * 5. Write a method that calculates the number of 
 * workdays between today and given date, passed as 
 * parameter. Consider that workdays are all days from 
 * Monday to Friday except a fixed list of public 
 * holidays specified preliminary as array.
 * 
 **********************************************************/

using System;

class GetWorkdaysTillDate
{
    static int WorkdaysTillDate(DateTime endDate, params DateTime[] holidays)
    {
        DateTime today = DateTime.Now.Date;
        endDate = endDate.Date;
        int workDays = 0;

        for (DateTime dt = today.AddDays(1); dt < endDate; dt = dt.AddDays(1))
        {
            if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
            {
                workDays++;
            }
        }

        foreach (var holiday in holidays)
        {
            if (today < holiday && holiday < endDate
                && holiday.DayOfWeek != DayOfWeek.Saturday && holiday.DayOfWeek != DayOfWeek.Sunday)
            {
                workDays--;
            }
        }

        return workDays;
    }

    static void Main()
    {
        DateTime endDate = new DateTime(2014, 1, 1);
        DateTime[] holidays = {
            new DateTime(2013, 9, 6),
            new DateTime(2013, 9, 22),
            new DateTime(2013, 12, 24),
            new DateTime(2013, 12, 25),
            new DateTime(2013, 12, 26),
            new DateTime(2013, 12, 31)
        };
        int workDays = WorkdaysTillDate(endDate, holidays);
        Console.WriteLine("Workdays till {0}: {1}", endDate, workDays);
    }
}
