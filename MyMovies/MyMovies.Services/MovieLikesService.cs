using MyMovies.Data;
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
            var like = new MovieLike
            {
                MovieId = movieId,
                UserId = userId,
                DateCreated = DateTime.Now,
                Status = true
            };

            movieLikesRepository.AddLike(like);
        }
    }
}
