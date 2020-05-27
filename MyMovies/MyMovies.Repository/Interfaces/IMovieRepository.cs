using MyMovies.Data;
//using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movies1> GetAll();

        Movies1 GetById(int id);
        void Add(Movies1 movie);
        //List<Movies1> GetByTitle(string title);
    }
}
