using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Program
    {
        static Engine GetEngineInstance()
        {
            return new Engine();
        }

        static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();

            Console.SetIn(new StreamReader("../../input.txt"));

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}
