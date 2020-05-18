using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }
//Required se koristi za da mora da se vnese nesto vo poleto
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Required]
        public string Cast { get; set; }
        //public List<string> Cast { get; set; }

        //[Required]
        //[MaxLength(5000)]
    }
}
