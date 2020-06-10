using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;

namespace MyMovies.Controllers
{
    public class MovieCommentController : Controller
    {
        public IMovieComments MovieCommentsService { get; set; }
        public MovieCommentController(IMovieComments movieComments)
        {
            MovieCommentsService = movieComments;
        }

        [HttpPost]
        public IActionResult Add(string comment,int movieId)
        {
            if (!String.IsNullOrEmpty(comment))
            {
                var userId = Convert.ToInt32(User.FindFirst("Id").Value);
                MovieCommentsService.Add(comment, movieId, userId);
            }
            return RedirectToAction("Details", "Movies", new { id = movieId }); //zatoa sto se vrakjame na details a details bara id
        }
    }
}