﻿using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository.Interfaces
{
    public interface IMovieLikesRepository
    {
        void AddLike(MovieLike like);
    }
}
