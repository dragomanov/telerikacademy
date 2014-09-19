using ToyStore.Models;

namespace ToyStore.DataGenerator
{
    public class CountryFactory
    {
        public Country Create()
        {
            var rng = RNG.GetInstance();
            var country = new Country
            {
                Name = rng.GenerateString(5, 20)
            };

            return country;
        }
    }
}
