using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MyMovies.Models;
using Newtonsoft.Json;
using System.Linq;

namespace MyMovies.Repository
{
    public class MovieFileRepository: IMovieRepository
    {

        public List<Movie> Movies { get; set; }
        public MovieFileRepository()
        {
            var movies = File.ReadAllText("movies.txt");
            Movies = JsonConvert.DeserializeObject<List<Movie>>(movies);
        }
        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x=>x.ID==id);
        }

        
    }

}
