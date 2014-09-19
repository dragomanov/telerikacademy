using ToyStore.Models;

namespace ToyStore.DataGenerator
{
    public class ToyTypeFactory
    {
        public ToyType Create()
        {
            var rng = RNG.GetInstance();
            var toyType = new ToyType
            {
                Name = rng.GenerateString(5, 20)
            };

            return toyType;
        }
    }
}
