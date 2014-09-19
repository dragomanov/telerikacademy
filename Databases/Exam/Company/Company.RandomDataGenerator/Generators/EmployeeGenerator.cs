using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.RandomDataGenerator.Generators
{
    internal class EmployeeGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeGenerator(CompanyDbContext db)
            : base(db)
        {
        }

        public override void Generate(int numberOfObjects)
        {
            base.Generate(numberOfObjects);
            var numberOfDepartments = this.db.Departments.Count();
            Console.WriteLine("Generating {0} employees", this.count);

            int i = 0;
            while (this.count > i)
            {
                int? managerId = null;
                if (this.rng.GenerateNumber(1, 100) <= 95)
                {
                    // All new employees have a manager that's been hired before them, therefore no loops are created
                    managerId = this.rng.GenerateNumber(1, i);
                }
                var newObj = new Employee
                {
                    FirstName = this.rng.GenerateString(5, 20),
                    LastName = this.rng.GenerateString(5, 20),
                    YearSalary = this.rng.GenerateNumber(500, 2000) * 100,
                    DepartmentId = this.rng.GenerateNumber(1, numberOfDepartments),
                    ManagerId = managerId
                };

                this.db.Employees.Add(newObj);

                i++;
                if (i % 100 == 0)
                {
                    Console.WriteLine(i);
                    this.db.SaveChanges();
                }
            }

            this.db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Generated {0} employees in database", this.count);
        }
    }
}
