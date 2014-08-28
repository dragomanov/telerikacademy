using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TreesAndTraversals
{
    public class Folder
    {
        private string name;
        private IList<File> files;
        private IList<Folder> childFolders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>();
            this.childFolders = new List<Folder>();
        }


        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Folder name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public IList<File> Files
        {
            get
            {
                return new ReadOnlyCollection<File>(this.files);
            }
        }

        public IList<Folder> ChildFolders
        {
            get
            {
                return new ReadOnlyCollection<Folder>(this.childFolders);
            }
        }

        public long GetFilesSize()
        {
            long size = 0;

            foreach (var file in files)
            {
                size += file.Size;
            }

            foreach (var childFolder in childFolders)
            {
                size += childFolder.GetFilesSize();
            }

            return size;
        }

        public void AddFile(string name, long size)
        {
            File file = new File(name, size);
            files.Add(file);
        }

        public void AddFolder(string name)
        {
            Folder folder = new Folder(name);
            childFolders.Add(folder);
        }
    }
}
