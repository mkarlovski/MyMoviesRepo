using MyMovies.Data;
//using MyMovies.Models;
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

        public List<Movies1> GetAll()
        {
            //var movieRepository = new MovieRepository();
            //var movies = movieRepository.GetAll();

            var movies = MovieRepository.GetAll();
            return movies;

        }

        public Movies1 GetById(int id)
        {
            //var movieRepository = new MovieRepository();
            //var movie = movieRepository.GetById(id);
            var movie = MovieRepository.GetById(id);
            return movie;
        }

        public void CreateMovie(Movies1 movie)
        {
            //get all movies
            //get max id
            //generate new id=max id+1
            //add new id to new recipe
            //add recipe in db
            MovieRepository.Add(movie);

        }

        public List<Movies1> GetByTitle(string title)
        {
            return MovieSQLRepository.GetByTitle(title);
        }
    }
}
