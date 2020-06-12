using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Data;
//using MyMovies.Models;
//using MyMovies.Models;

namespace MyMovies.Controllers
{
    public class InfoController : Controller
    {
        
 
        public IActionResult AboutUs()
        {
            ViewBag.CompanyName = "Code Academy";
            ViewBag.CurrentDate = DateTime.Now.ToString();
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
