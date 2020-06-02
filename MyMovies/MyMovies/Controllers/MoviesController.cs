﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Data;
using MyMovies.Helpers;
//using MyMovies.Models;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
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
            
            var movies = MoviesService.GetByTitle(title);
            var overviewViewModels = movies.Select(x => ModelConverter.ConvertToOverviewModel(x)).ToList();
            //var overviewViewModels = new List<OverviewViewModel>();

            //foreach(var movie in movies)
            //{
            //    var viewModel = new OverviewViewModel()
            //    {
            //        Id = movie.Id,
            //        Title=movie.Title,
            //        ImageUrl=movie.ImageUrl,
            //        Description=movie.Description,
            //        DaysCreated = DateTime.Now.Subtract(movie.DateCreated.Value).Days

            //    };
            //    overviewViewModels.Add(viewModel);                
            //}

            return View(overviewViewModels);
            //return View(movies);
        }
        public IActionResult Details(int ID)
        {
           
            var movie = MoviesService.GetMovieDetails(ID);
            var movieDetails = ModelConverter.ConvertToMovieDetailsModel(movie);
            return View(movieDetails);
        }
        public IActionResult Create()
        {
            //var movie = new Movie();   //so ova mu kazuvame na view deka moze da raboti so movie model i pomaga za kreiranje na formata
            var movie = new MovieCreateModel();
            return View(movie);
        }
        [HttpPost]   //povika sto ceka podatoci
        public IActionResult Create(MovieCreateModel createMovie)
        {
            //call service to create add new movie
            if (ModelState.IsValid)   //ako site parametri se vneseni na modelot togas ke se kreira nov objekt
            {
                var movie = ModelConverter.ConvertFromCreateModel(createMovie);
                MoviesService.CreateMovie(movie);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(createMovie);
            }
        }

        public IActionResult ModifyOverview()
        {
            var movies = MoviesService.GetAll();
            var modifyOverviewModels = movies.Select(x => ModelConverter.ConvertToModifyOverviewModel(x)).ToList();
            return View(movies);
        }

        public IActionResult Delete(int id)
        {
            //logic to delete movie
            MoviesService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }

        public IActionResult Modify(int id)
        {
            var movie = MoviesService.GetById(id);
            var movieModify = ModelConverter.ConvertToMovieModify(movie);
            return View(movieModify);
        }

        [HttpPost]
        public IActionResult Modify(MovieModifyModel modifyMovie)
        {
            //logic for update
            if (ModelState.IsValid)
            {
                var movie = ModelConverter.ConvertFromMovieModify(modifyMovie);
                MoviesService.UpdateMovie(movie);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(modifyMovie);
            }           
        }
    }
}
