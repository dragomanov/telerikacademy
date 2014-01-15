namespace WarMachines
{
    using System;
    using System.IO;
    using WarMachines.Engine;

    public class WarMachinesProgram
    {
        public static void Main()
        {
            const string fn = "test.000.001.in.txt";
            if (File.Exists(fn))
                Console.SetIn(new StreamReader(fn));
            WarMachineEngine.Instance.Start();
        }
    }
}
