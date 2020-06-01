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
    }
}
