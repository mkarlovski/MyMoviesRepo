using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Data
{
    public class MyMoviesDBContext :DbContext
    {
        public MyMoviesDBContext(DbContextOptions<MyMoviesDBContext> options) : base(options)  //constructor
        {

        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MovieComment> MovieComments { get; set; }
        public virtual DbSet<MovieLike> MovieLikes { get; set; }


    }
}
