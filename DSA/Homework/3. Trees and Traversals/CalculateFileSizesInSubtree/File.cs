namespace TreesAndTraversals
{
    public class File
    {
        string name;
        long size;

        public string Name
        {
            get { return this.name; }
        }

        public long Size
        {
            get { return this.size; }
        }

        public File(string name, long size)
        {
            this.name = name;
            this.size = size;
        }
    }
}
