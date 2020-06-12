using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieCommentApproveModel
    {
        public int Id { get; set; }
        public string  Username { get; set; }
        public string Movie { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsApproved { get; set; }
    }
}
