using MyMovies.Data;
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
    }
}
