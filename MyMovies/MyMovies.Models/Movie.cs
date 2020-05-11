using System;
using System.Collections.Generic;

namespace MyMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public List<string> Cast { get; set; }
    }
}
