/*
 * 2. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively 
 * and to display all files matching the mask *.exe. Use the class System.IO.Directory.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace TreesAndTraversals
{
    class FindExesInWindows
    {
        static void Main(string[] args)
        {
            ThreadStart threadDelegate = new ThreadStart(GetAllFilesDelegate); 
            Thread newThread = new Thread(threadDelegate, 10000000);
            newThread.Start();
        }

        public static void GetAllFilesDelegate()
        {
            GetAllFilesInDirectory(@"C:\WINDOWS", "*.exe");
        }

        public static List<string> GetAllFilesInDirectory(string directory, string pattern)
        {
            List<string> files = new List<string>();
            Queue<string> directories = new Queue<string>();
            directories.Enqueue(directory);

            GetAllFilesInDirectoryRecursively(directories, files, pattern);

            return files;
        }

        private static void GetAllFilesInDirectoryRecursively(Queue<string> directories, List<string> files, string pattern)
        {
            string directory = directories.Dequeue();
            IEnumerable<string> filesInDir;

            try
            {
                filesInDir = Directory.GetFiles(directory, pattern);
                files.AddRange(filesInDir);
                foreach (var dir in Directory.GetDirectories(directory))
                {
                    directories.Enqueue(dir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                filesInDir = new string[0];
            }

            if (filesInDir.Count() > 0)
            {
                Console.WriteLine(String.Join("\n", filesInDir));
            }

            if (directories.Count == 0)
            {
                return;
            }
            else
            {
                GetAllFilesInDirectoryRecursively(directories, files, pattern);
            }
        }
    }
}
