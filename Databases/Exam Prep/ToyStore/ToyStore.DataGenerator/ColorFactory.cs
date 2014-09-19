using ToyStore.Models;

namespace ToyStore.DataGenerator
{
    public class ColorFactory
    {
        public Color Create()
        {
            var rng = RNG.GetInstance();
            var color = new Color
            {
                Name = rng.GenerateString(5, 20)
            };

            return color;
        }
    }
}
