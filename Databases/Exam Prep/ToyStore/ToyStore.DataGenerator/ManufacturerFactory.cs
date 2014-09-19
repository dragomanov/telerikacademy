using ToyStore.Models;

namespace ToyStore.DataGenerator
{
    public class ManufacturerFactory
    {
        public Manufacturer Create()
        {
            var rng = RNG.GetInstance();
            var manufacturer = new Manufacturer
            {
                Name = rng.GenerateString(5, 20)
            };

            return manufacturer;
        }
    }
}
