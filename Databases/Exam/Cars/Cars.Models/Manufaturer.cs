namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufaturer
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(10), Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
