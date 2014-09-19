using System;
using System.Collections.Generic;
using Company.RandomDataGenerator.Generators;

namespace Company.RandomDataGenerator
{
    internal class RDGClient
    {
        static void Main()
        {
            var db = new CompanyDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;

            new DepartmentGenerator(db).Generate(100);
            new EmployeeGenerator(db).Generate(5000);
            new ProjectGenerator(db).Generate(1000);
            new ReportsGenerator(db).Generate(250000);

            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;

            Console.WriteLine("All objects generated successfully!");
        }
    }
}
