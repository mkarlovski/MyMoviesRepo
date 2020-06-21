using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
   public interface IMovieLikeService
    {
        void AddLike(int userId, int movieId);

    }
}
