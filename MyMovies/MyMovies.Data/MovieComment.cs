using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyMovies.Data
{
    public class MovieComment
    {
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsApproved { get; set; }

        [Required]
        public int MovieId { get; set; }   //ova ni e foreign key vo baza. i spored name znae deka e za movie
        public Movie Movie { get; set; } //navigacisko property

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
