using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Program
    {
        static void Main(string[] args)
        {
            string fn = "input.txt";
            if (File.Exists(fn))
                Console.SetIn(new StreamReader(fn));
            var engine = new Engine(new ExtendedInteractionManager());
            engine.Start();
        }
    }
}
