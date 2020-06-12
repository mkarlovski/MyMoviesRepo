using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string ImageUrl { get; set; }
        
        public string Description { get; set; }
        
        public string Cast { get; set; }
       
        public DateTime? DateCreated { get; set; }
        public int Views { get; set; }
        public List<MovieCommentModel> MovieComments { get; set; }
        public SidebarData Sidebar { get; set; }
    }
}
