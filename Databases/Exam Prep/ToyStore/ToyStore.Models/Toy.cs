using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
    public class Toy
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Manufacturer Manufacturer { get; set; }
        public ToyType Type { get; set; }
        public Color Color { get; set; }
        public AgeRange AreRange { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
