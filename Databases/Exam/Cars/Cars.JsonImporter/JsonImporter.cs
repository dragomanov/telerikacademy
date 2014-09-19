namespace Cars.JsonImporter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cars.Data;
    using Cars.Models;
    using Newtonsoft.Json;
    using System.IO;

    public class JsonImporter
    {
        public static void Main()
        {
            var db = new CarsDbContext();
            for (int i = 0; i < 5; i++)
            {
                var json = File.ReadAllText("../../data/data." + i + ".json");
                var cars = JsonConvert.DeserializeObject<ICollection<JsonCar>>(json);
                var j = 1;

                foreach (var car in cars)
                {
                    if (j % 100 == 0)
                    {
                        Console.WriteLine(j);
                        db.SaveChanges();
                    }
                    j++;
                }
            }
        }
    }
}
