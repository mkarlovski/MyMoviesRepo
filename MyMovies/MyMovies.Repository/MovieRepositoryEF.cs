using MyMovies.Data;
//using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class MovieRepositoryEF : IMovieRepository
    {
        private MyMoviesDBContext Context { get; set; }
        public MovieRepositoryEF(MyMoviesDBContext context)
        {
            Context = context;
        }
        
        public void Add(Movies1 movie)
        {
            movie.DateCreated = DateTime.Now;
            Context.Movies1.Add(movie);
            Context.SaveChanges();
        }

        public List<Movies1> GetAll()
        {
            return Context.Movies1.ToList();
        }

        public Movies1 GetById(int id)
        {
            return Context.Movies1.FirstOrDefault(x => x.Id == id);
        }

        public List<Movies1> GetByTitle(string title)
        {
            var movies = Context.Movies1.AsQueryable();
            if (!string.IsNullOrEmpty(title))
            {
                movies = movies.Where(x => x.Title.Contains(title));
            }
            return movies.ToList();
        }
    }
}
