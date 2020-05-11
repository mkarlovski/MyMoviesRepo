using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
using MyMovies.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        
        
        public IActionResult Overview()
        {
            var service = new MoviesService();
            var movies = service.GetAll();
            return View(movies);
        }
        public IActionResult Details(int ID)
        {
            var service = new MoviesService();
            var movie = service.GetById(ID);
            return View(movie);
        }
    }
}
