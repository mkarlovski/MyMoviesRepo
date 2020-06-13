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
                Username=user.Username,
                IsAdmin=user.IsAdmin
                
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

        public static MovieCommentApproveModel ConvertToMovieCommentApprove(MovieComment x)
        {
            return new MovieCommentApproveModel
            {
                Id=x.Id,
                Username=x.User.Username,
                Movie=x.Movie.Title,
                DateCreated=x.DateCreated,
                Comment=x.Comment,
                IsApproved=x.IsApproved
            };
        }

        public static UserModifyModel ConvertToUserModifyModel(User user)
        {
            return new UserModifyModel
            {
                Id=user.Id,
                Username=user.Username,
                IsAdmin=user.IsAdmin
            };
        }

        public static MovieCommentModel ConvertToMovieCommentModel(MovieComment movieComment)
        {
            return new MovieCommentModel
            {
                Comment = movieComment.Comment,
                DateCreated = movieComment.DateCreated,
                Username = movieComment.User.Username,
                IsApproved=movieComment.IsApproved
            };
        }

        public static User ConvertFromUserModifyModel(UserModifyModel userModifyModel)
        {
            return new User
            {
                Id=userModifyModel.Id,
                Username=userModifyModel.Username,
                IsAdmin=userModifyModel.IsAdmin
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
