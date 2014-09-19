using ToyStore.Models;

namespace ToyStore.DataGenerator
{
    class AgeRangeFactory
    {
        public AgeRange Create()
        {
            var rng = RNG.GetInstance();
            var ageRange = new AgeRange
            {
                MinAge = rng.GenerateNumber(0, 20),
                MaxAge = rng.GenerateNumber(21, 50)
            };

            return ageRange;
        }
    }
}
