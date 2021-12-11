﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime RealeaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

    }
}
