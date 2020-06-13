﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Custom;
using MyMovies.Helpers;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        
        public IUserService UserService { get; set; }
        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        [Authorize(Policy ="IsAdmin")]  //samo administrator moze da pravi promeni na users
        public IActionResult UsersModifyOverview()
        {
            var users = UserService.GetAll();
            var modifyUserOverview = users.Select(x => ModelConverter.ConvertToModifyUserOverviewModel(x)).ToList();
            return View(modifyUserOverview);
        }

        
        public IActionResult Delete(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User,id))   //ova proveruva dali userot e admin i dali e istion toj user pa da ne se izbrise sam
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            UserService.Delete(id);

            if (Convert.ToInt32(User.FindFirst("Id").Value) == id)   
            {
                return RedirectToAction("SignOut", "Auth");
            }

            return RedirectToAction("SuccessfulUserChange");
        }

        public IActionResult SuccessfulUserChange()
        {
            return View();
        }

        public IActionResult Modify(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            var user = UserService.GetById(id);
            var modifyUser = ModelConverter.ConvertToUserModifyModel(user);


            return View(modifyUser);
        }

        [HttpPost]
        public IActionResult Modify(UserModifyModel userModifyModel)
        {
            if(!AuthorizeService.AuthorizeUser(User, userModifyModel.Id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            if (ModelState.IsValid)
            {
                var user = ModelConverter.ConvertFromUserModifyModel(userModifyModel);
                var result = UserService.ModifyUser(user);

                if (result.Status)
                {
                    return RedirectToAction("SuccessfulUserChange");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(userModifyModel);
        }





    }
}