using System;
using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public class MovieModel
    {
        [Required]
        [MaxLength(10)]
        public uint Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Thumbnail { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }
    }
}