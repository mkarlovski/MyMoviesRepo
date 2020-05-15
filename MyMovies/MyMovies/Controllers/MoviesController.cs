using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {

        public IMovieService MoviesService { get; set; }

        public MoviesController(IMovieService moviesService)
        {
            MoviesService = moviesService;
        }
        //public MoviesController()
        //{
        //    MoviesService = new MoviesService();
        //}

        public IActionResult Overview()
        {
            //var service = new MoviesService();
            //var movies = service.GetAll();

            var movies = MoviesService.GetAll();
            return View(movies);
        }
        public IActionResult Details(int ID)
        {
            //var service = new MoviesService();
            //var movie = service.GetById(ID);

            var movie = MoviesService.GetById(ID);
            return View(movie);
        }
        public IActionResult Create()
        {
            var movie = new Movie();
            return View(movie);
        }
        [HttpPost]   //povika sto ceka podatoci
        public IActionResult Create(Movie movie)
        {
            //call service to create add new movie
            return RedirectToAction("Overview");
        }
    }
}
