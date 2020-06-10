using MyMovies.Data;
using MyMovies.Repository.Interfaces;
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
    }
}
