namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public short Year { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public virtual Manufaturer Manufacturer { get; set; }

        [Required, EnumDataType(typeof(TransmissionType))]
        public virtual TransmissionType TransmissionType { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }
    }
}
