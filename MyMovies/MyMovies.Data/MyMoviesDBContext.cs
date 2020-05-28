using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Data
{
    public class MyMoviesDBContext :DbContext
    {
        public MyMoviesDBContext(DbContextOptions<MyMoviesDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Movie> Movies { get; set; }
    }
}
