using MyMovies.Repository.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class MovieLikesService : IMovieLikeService
    {
        private readonly IMovieLikesRepository movieLikesRepository;

        public MovieLikesService(IMovieLikesRepository movieLikesRepository )
        {
            this.movieLikesRepository = movieLikesRepository;
        }

        public void AddLike(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
