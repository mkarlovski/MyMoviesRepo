using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Data
{
    public class MovieComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }


        public int MovieId { get; set; }   //ova ni e foreign key vo baza. i spored name znae deka e za movie
        public Movie Movie { get; set; } //navigacisko property

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
