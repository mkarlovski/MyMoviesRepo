using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class MovieLikesController : Controller
    {
        private readonly IMovieLikeService movieLikeService;

        public MovieLikesController(IMovieLikeService movieLikeService )
        {
            this.movieLikeService = movieLikeService;
        }

        public IActionResult Index([FromBody] MovieLikeRequestModel movieLikeViewModel)  //from body zosto od body na http request
        {
            var userId = Convert.ToInt32(User.FindFirst("Id").Value);
            movieLikeService.AddLike(userId, movieLikeViewModel.MovieId);
            return Ok();
        }
    }
}