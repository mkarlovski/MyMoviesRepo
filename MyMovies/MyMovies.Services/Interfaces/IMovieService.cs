using MyMovies.Data;
//using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
   public interface IMovieService
    {
        List<Movies1> GetAll();
        Movies1 GetById(int id);
        void CreateMovie(Movies1 movie);
        List<Movies1> GetByTitle(string title);
    }
}
