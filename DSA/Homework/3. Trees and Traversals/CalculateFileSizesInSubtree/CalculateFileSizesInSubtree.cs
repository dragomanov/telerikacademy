/*
 * 3. Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } 
 * and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. 
 * Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. 
 * Use recursive DFS traversal. 
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace TreesAndTraversals
{
    public class CalculateFileSizesInSubtree
    {
        public static void Main()
        {
            const string RootDirectory = "C:\\windows";
            const string FilePattern = "*.*";

            Folder root = new Folder(RootDirectory);
            CreateFolders(root, FilePattern);

            Console.WriteLine("Folder: " + root.Name);
            Console.WriteLine("Size in bytes: " + root.GetFilesSize());
        }

        private static void CreateFolders(Folder root, string filePattern)
        {
            try
            {
                string[] files = Directory.GetFiles(root.Name, filePattern);
                string[] folders = Directory.GetDirectories(root.Name);
                if (files.Length == 0 && folders.Length == 0)
                {
                    return;
                }
                else
                {
                    FileInfo fileInfo;
                    long size;
                    foreach (var fileName in files)
                    {
                        fileInfo = new FileInfo(fileName);
                        size = fileInfo.Length;
                        root.AddFile(fileName, size);
                    }

                    foreach (var folderName in folders)
                    {
                        root.AddFolder(folderName);
                        CreateFolders(root.ChildFolders[root.ChildFolders.Count - 1], filePattern);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}