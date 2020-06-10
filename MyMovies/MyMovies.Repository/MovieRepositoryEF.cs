using Microsoft.EntityFrameworkCore;
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
        
        public void Add(Movie movie)
        {
            movie.DateCreated = DateTime.Now;
            Context.Movies.Add(movie);
            Context.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return Context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return Context.Movies
                .Include(x=>x.MovieComments)
                    .ThenInclude(x=>x.User)
                        .FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetByTitle(string title)
        {
            var movies = Context.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(title))
            {
                movies = movies.Where(x => x.Title.Contains(title));
            }
            return movies.ToList();
        }

        public void Update(Movie movie)
        {
            Context.Movies.Update(movie);
            //Context.Entry<Movie>(movie).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = new Movie()       //so ova skratuvame eden povik do baza zosto mu kazuvame direktno koj movie da go izbrise spored ID
            {
                Id = id
            };
            Context.Movies.Remove(movie);
            Context.SaveChanges();
        }

       
    }
}
