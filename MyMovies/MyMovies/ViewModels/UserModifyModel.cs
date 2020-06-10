using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class UserModifyModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public List<MovieComment> MovieComments { get; set; }
    }
}
