using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();

        Movie GetById(int id);
        void Add(Movie movie);
    }
}
