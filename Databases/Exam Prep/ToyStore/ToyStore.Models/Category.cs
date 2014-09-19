using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
    public class Category
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Toy> Toys { get; set; }
    }
}
