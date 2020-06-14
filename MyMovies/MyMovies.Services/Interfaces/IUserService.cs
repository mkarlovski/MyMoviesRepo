using MyMovies.Data;
using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        ModifyUserResult ModifyUser(User user);
        void ChangePassword(int id, string password);
        string CreateUser(string username, string password, bool isAdmin);
    }
}
