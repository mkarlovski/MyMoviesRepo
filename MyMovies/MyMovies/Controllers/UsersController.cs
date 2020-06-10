using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Helpers;
using MyMovies.Services.Interfaces;

namespace MyMovies.Controllers
{
    public class UsersController : Controller
    {
        public IUserService UserService { get; set; }
        public UsersController(IUserService userService)
        {
            UserService = userService;
        }
        public IActionResult UsersModifyOverview()
        {
            var users = UserService.GetAll();
            var modifyUserOverview = users.Select(x => ModelConverter.ConvertToModifyUserOverviewModel(x)).ToList();
            return View(modifyUserOverview);
        }
    }
}