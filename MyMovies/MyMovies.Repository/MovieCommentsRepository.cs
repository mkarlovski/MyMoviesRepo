using Microsoft.EntityFrameworkCore;
using MyMovies.Data;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class MovieCommentsRepository : IMovieCommentRepository
    {
        public MyMoviesDBContext Context { get; set; }
        public MovieCommentsRepository(MyMoviesDBContext context)
        {
            Context = context;
        }

        public void Add(MovieComment newComment)
        {
            Context.MovieComments.Add(newComment);
            Context.SaveChanges();
        }

        public List<MovieComment> GetAll()
        {
            return Context.MovieComments.Include(x=>x.Movie).Include(x=>x.User).ToList();
        }
    }
}
