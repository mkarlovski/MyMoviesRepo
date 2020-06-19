using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class MovieLikesController : Controller
    {
        public IActionResult Index([FromBody] MovieLikeViewModel movieLikeViewModel)  //from body zosto od body na http request
        {
            var userId = Convert.ToInt32(User.FindFirst("Id").Value);
            MovieLikesService.AddLike(userId, movieLikeViewModel.MovieId);
            return Ok();
        }
    }
}