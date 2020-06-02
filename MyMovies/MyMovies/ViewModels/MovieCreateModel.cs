using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieCreateModel
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Cast { get; set; }
    }
}
