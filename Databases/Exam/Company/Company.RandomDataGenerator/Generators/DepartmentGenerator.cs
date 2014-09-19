using System;
using System.Collections.Generic;
using System.Linq;

namespace Company.RandomDataGenerator.Generators
{
    internal class DepartmentGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentGenerator(CompanyDbContext db)
            : base(db)
        {
        }

        public override void Generate(int numberOfObjects)
        {
            base.Generate(numberOfObjects);
            var generatedList = new HashSet<Department>();
            var generatedNames = new HashSet<string>();
            Console.WriteLine("Generating {0} deparments", this.count);

            int i = 0;
            while (this.count > generatedNames.Count)
            {
                string uniqueName;
                do
                {
                    uniqueName = this.rng.GenerateString(10, 50);
                }
                while(generatedNames.Contains(uniqueName));

                generatedNames.Add(uniqueName);

                var newObj = new Department
                {
                    Name = uniqueName
                };

                generatedList.Add(newObj);

                if (i % 100 == 99)
                {
                    Console.WriteLine(generatedNames.Count);
                    this.db.Departments.AddRange(generatedList);
                    this.db.SaveChanges();
                    generatedList.Clear();
                }
                i++;
            }

            this.db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Generated {0} departments in database", this.count);
        }
    }
}
