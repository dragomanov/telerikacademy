namespace TreesAndTraversals
{
    class File
    {
        string name;
        int size;

        public string Name
        {
            get { return this.name; }
        }

        public int Size
        {
            get { return this.size; }
        }

        public File(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
    }
}
