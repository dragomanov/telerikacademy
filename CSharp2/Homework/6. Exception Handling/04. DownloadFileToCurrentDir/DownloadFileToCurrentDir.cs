/**********************************************************
 * 
 * 4. Write a program that downloads a file from Internet 
 * (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and 
 * stores it the current directory. Find in Google how to 
 * download files in C#. Be sure to catch all exceptions 
 * and to free any used resources in the finally block.
 * 
 **********************************************************/

using System;
using System.Net;
using System.IO;

class DownloadFileToCurrentDir
{
    static void Main()
    {
        WebClient client = new WebClient();
        try
        {
            Uri uri = new Uri(Console.ReadLine());
            client.DownloadFile(uri, Directory.GetCurrentDirectory() + '\\' + Path.GetFileName(uri.LocalPath));
        }
        catch (UriFormatException ufe)
        {
            Console.WriteLine(ufe.Message);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (WebException we)
        {
            Console.WriteLine(we.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine(nse.Message);
        }
        finally
        {
            // no need for finally since DownloadFile doesn't leave open tcp connections
        }
    }
}
