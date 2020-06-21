using MyMovies.Data;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository
{
    public class MovieLikesRepository : IMovieLikesRepository
    {
        private readonly MyMoviesDBContext context;

        public MovieLikesRepository(MyMoviesDBContext context)
        {
            this.context = context;
        }
    }
}
