using MyMovies.Models;
using MyMovies.Repository;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;


namespace MyMovies.Services
{
    public class MoviesService : IMovieService
    {

        public IMovieRepository MovieRepository { get; set; }

        public MoviesService(IMovieRepository movieRepo)
        {
            MovieRepository = movieRepo;
            //MovieRepository = new MovieRepository();
        }

        public List<Movie> GetAll()
        {
            //var movieRepository = new MovieRepository();
            //var movies = movieRepository.GetAll();

            var movies = MovieRepository.GetAll();
            return movies;

        }

        public Movie GetById(int id)
        {
            //var movieRepository = new MovieRepository();
            //var movie = movieRepository.GetById(id);
            var movie = MovieRepository.GetById(id);
            return movie;
        }

    }
}
