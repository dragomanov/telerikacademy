using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
