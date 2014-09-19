using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
    public class ToyType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
