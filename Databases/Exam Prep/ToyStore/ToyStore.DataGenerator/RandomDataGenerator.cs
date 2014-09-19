using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.DataGenerator
{
    public class RandomDataGenerator
    {
        private ToyStoreDbContext db;

        public RandomDataGenerator(ToyStoreDbContext db)
        {
            this.db = db;
        }

        public void GenerateData()
        {
            db.Configuration.AutoDetectChangesEnabled = false;
            Console.WriteLine("Generating colors");
            GenerateMany(this.db.Colors, 50);
            Console.WriteLine("Colors generated");
            Console.WriteLine("Generating toy types");
            GenerateMany(this.db.ToyTypes, 50);
            Console.WriteLine("Toy types generated");
            Console.WriteLine("Generating age ranges");
            GenerateMany(this.db.AgeRanges, 50);
            Console.WriteLine("Age ranges generated");
            Console.WriteLine("Generating countries");
            GenerateMany(this.db.Countries, 100);
            Console.WriteLine("Countries generated");
            Console.WriteLine("Generating manufacturers");
            GenerateMany(this.db.Manufacturers, 100);
            Console.WriteLine("Manufacturers generated");
            Console.WriteLine("Generating categories");
            GenerateMany(this.db.Categories, 100);
            Console.WriteLine("Categories generated");
            db.Configuration.AutoDetectChangesEnabled = true;
        }

        public void GenerateMany<T>(DbSet<T> set, int count)
            where T : class
        {
            var dataSet = new HashSet<T>();
            var factory = new Factory();

            int i = 1;
            while (dataSet.Count() < count)
            {
                if (i % 100 == 0)
                {
                    Console.Write('.');
                }
                dataSet.Add(factory.Generate(typeof(T)));
                i++;
            }

            set.AddRange(dataSet);

            this.db.SaveChanges();
            Console.WriteLine();
        }
    }
}
