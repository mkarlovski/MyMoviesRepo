using MyMovies.Data;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Helpers
{
    public static class ModelConverter
    {
        public static OverviewViewModel ConvertToOverviewModel(Movie movie)
        {
            var overviewModel = new OverviewViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                DaysCreated = DateTime.Now.Subtract(movie.DateCreated.Value).Days
            };

            return overviewModel;
        }

        public static ModifyUserOverviewModel ConvertToModifyUserOverviewModel(User user)
        {
            return new ModifyUserOverviewModel
            {
                Id = user.Id,
                Username=user.Username
            };
        }

        public static MovieDetailsModel ConvertToMovieDetailsModel(Movie movie)
        {
            return new MovieDetailsModel
            {
                Id=movie.Id,
                Title=movie.Title,
                ImageUrl=movie.ImageUrl,
                Description=movie.Description,
                Cast=movie.Cast,
                DateCreated=movie.DateCreated,
                Views=movie.Views,
                MovieComments=movie.MovieComments.Select(x=>ConvertToMovieCommentModel(x)).ToList()
            };
        }

        public static MovieCommentModel ConvertToMovieCommentModel(MovieComment movieComment)
        {
            return new MovieCommentModel
            {
                Comment = movieComment.Comment,
                DateCreated = movieComment.DateCreated,
                Username = movieComment.User.Username
            };
        }

        public static ModifyOverviewModel ConvertToModifyOverviewModel(Movie movie)
        {
            return new ModifyOverviewModel
            {
                Id=movie.Id,
                Title=movie.Title
            };
        }

        public static Movie ConvertFromCreateModel(MovieCreateModel createMovie)
        {
            return new Movie
           {
               Title=createMovie.Title,
               ImageUrl=createMovie.ImageUrl,
               Description=createMovie.Description,
               Cast=createMovie.Cast
           };
        }

        public static Movie ConvertFromMovieModify(MovieModifyModel movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Description = movie.Description,
                Cast = movie.Cast,
                DateCreated = movie.DateCreated,
                Views = movie.Views
            };
        }

        public static MovieModifyModel ConvertToMovieModify(Movie movie)
        {
            return new MovieModifyModel
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Description = movie.Description,
                Cast = movie.Cast,
                DateCreated = movie.DateCreated,
                Views = movie.Views
            };
        }
    }
}
