using MyMovies.Data;
//using MyMovies.Models;
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
        List<Movie> GetByTitle(string title);
        Movie GetMovieDetails(int iD);
        void Delete(int id);
        void UpdateMovie(Movie movie);
    }
}
