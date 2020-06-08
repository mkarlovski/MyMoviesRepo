using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieCommentModel
    {
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }

    }
}
