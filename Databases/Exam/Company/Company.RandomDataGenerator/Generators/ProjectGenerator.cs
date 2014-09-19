using System;
using System.Collections.Generic;
using System.Linq;


namespace Company.RandomDataGenerator.Generators
{
    internal class ProjectGenerator : DataGenerator, IDataGenerator
    {
        public ProjectGenerator(CompanyDbContext db)
            : base(db)
        {
        }

        public override void Generate(int numberOfObjects)
        {
            base.Generate(numberOfObjects);
            var numberOfEmployees = this.db.Employees.Count();
            Console.WriteLine("Generating {0} projects", this.count);

            int i = 0;
            while (this.count > i)
            {
                var newObj = new Project
                {
                    Name = this.rng.GenerateString(5, 50)
                };

                this.db.Projects.Add(newObj);
                i++;

                if (i % 100 == 0)
                {
                    this.db.SaveChanges();
                }
            }

            this.db.SaveChanges();

            for (i = 1; i <= this.count; i++)
            {
                int teamSize = this.rng.GenerateNumber(0, 100) > 50 ? 5 : this.rng.GenerateNumber(2, 20);
                var employeesInProject = new HashSet<int>();
                for (int j = 0; j < teamSize; j++)
                {
                    int employeeId;
                    do
                    {
                        employeeId = this.rng.GenerateNumber(1, numberOfEmployees);
                    } while (employeesInProject.Contains(employeeId));

                    employeesInProject.Add(employeeId);
                    var startDate = this.rng.GenerateNumber(-365, 0);
                    var endDate = this.rng.GenerateNumber(startDate + 1, 365);
                    var newEmployeeProject = new EmployeesProject
                    {
                        EmployeeId = employeeId,
                        ProjectId = i,
                        StartDate = DateTime.Now.AddDays(startDate),
                        EndDate = DateTime.Now.AddDays(endDate)
                    };

                    this.db.EmployeesProjects.Add(newEmployeeProject);
                }

                if (i % 100 == 0)
                {
                    Console.WriteLine(i);
                    this.db.SaveChanges();
                }
            }

            this.db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Generated {0} projects in database", this.count);
        }
    }
}
