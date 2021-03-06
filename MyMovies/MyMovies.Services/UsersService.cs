﻿using MyMovies.Data;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class UsersService : IUserService
    {
        public IUserRepository UserRepository { get; set; }
        public UsersService(IUserRepository userRepo)
        {
            UserRepository = userRepo;
        }

        public List<User> GetAll()
        {
            return UserRepository.GetAll();
        }

        public void Delete(int id)
        {
            UserRepository.Delete(id);
        }

        public User GetById(int id)
        {
            return UserRepository.GetById(id);
        }

        public ModifyUserResult ModifyUser(User user)
        {
            var result = new ModifyUserResult();
            var currentUser = UserRepository.GetByUsername(user.Username);
            if(currentUser.Id==user.Id || currentUser == null)
            {
                var dbUser = UserRepository.GetById(user.Id);
                dbUser.Username = user.Username;
                dbUser.IsAdmin = user.IsAdmin;

                UserRepository.Update(dbUser);
                result.Status = true;
            }
            else
            {
                result.Status = false;
                result.Message = "Username already exist in database";
            }
            return result;

        }

        public void ChangePassword(int id, string password)
        {
            var user = UserRepository.GetById(id);
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            UserRepository.Update(user);
        }

        public string CreateUser(string username, string password, bool isAdmin)
        {
            string message = null;

            var user = UserRepository.GetByUsername(username);
            if (user == null)
            {
                var newUser = new User
                {
                    Username=username,
                    Password=BCrypt.Net.BCrypt.HashPassword(password),
                    IsAdmin=isAdmin
                };

                UserRepository.Add(newUser);
                return message;
            }
            else
            {
                message = "User already exists";
                return message;
            }
        }
    }
}
