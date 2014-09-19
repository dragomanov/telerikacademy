using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
