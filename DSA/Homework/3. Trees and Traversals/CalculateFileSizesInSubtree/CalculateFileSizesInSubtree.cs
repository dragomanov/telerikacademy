/*
 * 3. Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } 
 * and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. 
 * Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. 
 * Use recursive DFS traversal. 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace TreesAndTraversals
{
    class CalculateFileSizesInSubtree
    {
        static void Main(string[] args)
        {
            //ThreadStart threadDelegate = new ThreadStart(GetAllFilesDelegate);
            //Thread newThread = new Thread(threadDelegate, 10000000);
            //newThread.Start();


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
