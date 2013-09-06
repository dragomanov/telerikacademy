/**********************************************************
 * 
 * 3. Write a program that enters file name along with its 
 * full file path (e.g. C:\WINDOWS\win.ini), reads its 
 * contents and prints it on the console. Find in MSDN 
 * how to use System.IO.File.ReadAllText(…). Be 
 * sure to catch all possible exceptions and print user-
 * user-friendly error messages.
 * 
 **********************************************************/

using System;
using System.IO;
using System.Security;

class PrintFileContents
{
    static void Main()
    {
        try
        {
            string fullFileName = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            string fileContents = File.ReadAllText(fullFileName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(fileContents);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Error reading file contents: Null filename entered.");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine("Error reading file contents: " + ae.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine("Error reading file contents: " + ptle.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine("Error reading file contents: " + dnfe.Message);
        }
        catch (FileLoadException fnfe)
        {
            Console.WriteLine("Error reading file contents: " + fnfe.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Error reading file contents: " + ioe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine("Error reading file contents: " + uae.Message);
        }
        catch (SecurityException se)
        {
            Console.WriteLine("Error reading file contents: " + se.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine("Error reading file contents: " + nse.Message);
        }
    }
}
