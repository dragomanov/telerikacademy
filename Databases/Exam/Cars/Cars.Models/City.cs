namespace Cars.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        public City()
        {
            this.Dealers = new HashSet<Dealer>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(10), Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealers { get; set; }
    }
}
