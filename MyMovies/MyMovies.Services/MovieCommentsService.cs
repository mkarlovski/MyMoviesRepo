using MyMovies.Data;
using MyMovies.Repository;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class MovieCommentsService : IMovieComments

    {
        public IMovieCommentRepository MovieCommentsRepository { get; set; }
        public MovieCommentsService(IMovieCommentRepository commentRepository)
        {
            MovieCommentsRepository = commentRepository;
        }
        public void Add(string comment,int movieId, int userId)
        {
            //call repository to insert comment
            var newComment = new MovieComment
            {
                MovieId=movieId,
                UserId=userId,
                Comment=comment,
                DateCreated=DateTime.Now
            };
            MovieCommentsRepository.Add(newComment);

        }
    }
}
