using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyStore.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required, Index(IsUnique = true), MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Country Country { get; set; }
    }
}
