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

        public void Add(User newUser)
        {
            Context.Users.Add(newUser);
            Context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public void Delete(int id)
        {
            var user = new User()
            {
                Id = id
            };
            Context.Users.Remove(user);
            Context.SaveChanges();
        }

        public User GetById(int id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User dbUser)
        {
            Context.Users.Update(dbUser);
            Context.SaveChanges();
        }
    }
}
