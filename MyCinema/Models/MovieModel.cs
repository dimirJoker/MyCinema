﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public class MovieModel
    {
        public uint Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Thumbnail { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, uint.MaxValue)]
        public float Price { get; set; }
    }
}