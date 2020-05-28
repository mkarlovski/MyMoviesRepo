using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovies.Data
{
    public partial class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        //[Column("ImageURL")]
        public string ImageUrl { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Cast { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        public int Views { get; set; }
    }
}
