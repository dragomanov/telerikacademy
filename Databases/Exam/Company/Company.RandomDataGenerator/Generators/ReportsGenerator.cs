using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.RandomDataGenerator.Generators
{
    internal class ReportsGenerator : DataGenerator, IDataGenerator
    {
        public ReportsGenerator(CompanyDbContext db)
            : base(db)
        {
        }

        public override void Generate(int numberOfObjects)
        {
            base.Generate(numberOfObjects);
            var generatedList = new HashSet<Report>();
            var numberOfEmployees = this.db.Employees.Count();
            Console.WriteLine("Generating {0} reports", this.count);

            for (int i = 1; i <= numberOfEmployees; i++)
            {
                int numberOfReports = this.rng.GenerateNumber(1, 99);
                for (int j = 0; j < numberOfReports; j++)
                {
                    int arrivalTime = this.rng.GenerateNumber(-400, 0);
                    var newObj = new Report
                    {
                        EmployeeId = i,
                        TimeOfArrival = DateTime.Now.AddDays(-j).AddMinutes(arrivalTime),
                        ReportTime = DateTime.Now.AddDays(-j).AddMinutes(this.rng.GenerateNumber(arrivalTime + 1, 0))
                    };

                    generatedList.Add(newObj);
                }

                if (i % 100 == 0)
                {
                    Console.WriteLine(i);
                    this.db.Reports.AddRange(generatedList);
                    this.db.SaveChanges();
                    generatedList.Clear();
                }
            }

            this.db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Generated {0} reports in database", this.count);
        }
    }
}
