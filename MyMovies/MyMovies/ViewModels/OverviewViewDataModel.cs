using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class OverviewViewDataModel
    {
        public List<OverviewViewModel> Movies { get; set; }
        public SidebarData SidebarData { get; set; }
    }
}
