using MyMovies.Data;
//using MyMovies.Models;
using MyMovies.Repository;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Movie GetMovieDetails(int id)
        {
            var movie = MovieRepository.GetById(id);
            movie.Views += 1;
            MovieRepository.Update(movie);
            return movie;
        }

        public void CreateMovie(Movie movie)
        {
          
            MovieRepository.Add(movie);
        }

        public List<Movie> GetByTitle(string title)
        {
            return MovieRepository.GetByTitle(title);
        }

        public void Delete(int id)
        {
            MovieRepository.Delete(id);
        }

        public void UpdateMovie(Movie movie)
        {
            MovieRepository.Update(movie);
        }

        public SidebarData GetSidebarData()
        {
            //get all movies
            var movies=MovieRepository.GetAll();
            var topMovies = movies
                .OrderByDescending(x => x.Views)
                .Take(5)
                .Select(x=>new SidebarMovie
                {
                    DateCreated=x.DateCreated.Value,
                    Views=x.Views,
                    Title=x.Title
                })
                .ToList();
            //order by views and take 5
            //order by date created and take 5
            var recentMovies = movies.OrderByDescending(x => x.DateCreated).Take(5)
                .Select(x => new SidebarMovie
                {
                    DateCreated = x.DateCreated.Value,
                    Views = x.Views,
                    Title = x.Title
                }).ToList();
            //return movies
            var sidebarData = new SidebarData
            {
                TopMovies=topMovies,
                RecentMovies=recentMovies
            };
            return sidebarData;

        }
    }
}
