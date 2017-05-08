using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopXS_DruwelLaurens.ViewModels
{
    public class MoviesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public int Stars { get; set; }
        public IEnumerable<ActorViewModel> Actors { get; set; }




    }
}
