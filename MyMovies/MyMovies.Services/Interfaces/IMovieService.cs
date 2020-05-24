using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
   public interface IMovieService
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void CreateMovie(Movie movie);
        object GetByTitle(string title);
    }
}
