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
                Views=movie.Views
            };
        }

        public static ModifyOverviewModel ConvertToModifyOverviewModel(Movie x)
        {
            throw new NotImplementedException();
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

        internal static object ConvertFromMovieModify(MovieModifyModel modifyMovie)
        {
            throw new NotImplementedException();
        }

        internal static object ConvertToMovieModify(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
