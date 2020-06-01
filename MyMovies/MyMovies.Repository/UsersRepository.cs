using MyMovies.Data;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class UsersRepository : IUserRepository
    {
        private MyMoviesDBContext Context { get; set; }
        public UsersRepository(MyMoviesDBContext context)
        {
            Context = context;
        }
        public User GetByUsername(string username)
        {
            return Context.Users.FirstOrDefault(x=>x.Username==username);
        }
    }
}
