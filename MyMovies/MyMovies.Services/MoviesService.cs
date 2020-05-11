using MyMovies.Models;
using MyMovies.Repository;
using System;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class MoviesService
    {



        public List<Movie> GetAll()
        {
            var movieRepository = new MovieRepository();
            var movies = movieRepository.GetAll();
            return movies;

        }

        public Movie GetById(int id)
        {
            var movieRepository = new MovieRepository();
            var movie = movieRepository.GetById(id);
            return movie;
        }

    }
}
