using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieLikeModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }     //ako e true znaci e LIKED, ako e false togas e DISLIKE

    }
}
