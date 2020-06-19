using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyMovies.Data
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public List<MovieComment> MovieComments { get; set; }
        public List<MovieLike> MovieLikes { get; set; }
    }
}
