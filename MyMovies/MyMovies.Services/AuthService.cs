using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyMovies.Data;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    public class AuthService : IAuthService
    {
        public IUserRepository  UsersRepo { get; set; }
        public AuthService(IUserRepository userRepo)
        {
            UsersRepo = userRepo;
        }
        public async Task<bool> SignInAsync(string Username, string Password,HttpContext httpContext)
        {
            var user = UsersRepo.GetByUsername(Username);
            if(user!=null & BCrypt.Net.BCrypt.Verify(Password,user.Password))
            {
                //sign in user

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Username),
                    new Claim(ClaimTypes.Name,user.Username),
                    new Claim("IsAdmin",user.IsAdmin.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await httpContext.SignInAsync(principal);
                return true;
            }
            return false;
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        public bool SignUp(string username, string password)
        {
            var user = UsersRepo.GetByUsername(username);
            if(user == null)
            {
                var newUser = new User
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password)
                };
                UsersRepo.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
