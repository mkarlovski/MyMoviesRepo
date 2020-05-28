using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Data;
//using MyMovies.Models;
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

        public IActionResult Overview(string title)
        {
            //var service = new MoviesService();
            //var movies = service.GetAll();
            var movies = MoviesService.GetByTitle(title);
            //var movies = MoviesService.GetAll();
            return View(movies);
        }
        public IActionResult Details(int ID)
        {
            //var service = new MoviesService();
            //var movie = service.GetById(ID);

            //var movie = MoviesService.GetById(ID);
            var movie = MoviesService.GetMovieDetails(ID);
            return View(movie);
        }
        public IActionResult Create()
        {
            var movie = new Movie();   //so ova mu kazuvame na view deka moze da raboti so movie model i pomaga za kreiranje na formata
            return View(movie);
        }
        [HttpPost]   //povika sto ceka podatoci
        public IActionResult Create(Movie movie)
        {
            //call service to create add new movie
            if (ModelState.IsValid)   //ako site parametri se vneseni na modelot togas ke se kreira nov objekt
            {
                MoviesService.CreateMovie(movie);
                return RedirectToAction("Overview");
            }
            else
            {
                return View(movie);
            }
        }
    }
}
