using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string Username, string Password,HttpContext httpContext);
        Task SignOutAsync(HttpContext httpContext);
    }
}
