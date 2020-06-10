using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        
    }
}
