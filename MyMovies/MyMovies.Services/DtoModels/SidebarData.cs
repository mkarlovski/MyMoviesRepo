using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.DtoModels
{
    public class SidebarData
    {
        public List<SidebarMovie> TopMovies { get; set; }
        public List<SidebarMovie> RecentMovies { get; set; }
    }
}
