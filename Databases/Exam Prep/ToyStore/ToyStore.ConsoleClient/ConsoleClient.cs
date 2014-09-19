using System;
using System.Linq;
using ToyStore.Data;
using ToyStore.DataGenerator;

namespace ToyStore.ConsoleClient
{
    class ConsoleClient
    {
        static void Main()
        {
            var db = new ToyStoreDbContext();
            var generator = new RandomDataGenerator(db);
            generator.GenerateData();
            //foreach (var cat in db.Categories)
            //{
            //    Console.WriteLine("{0}: {1}", cat.Name, String.Join(", ", cat.Toys));
            //}
        }
    }
}
