using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopXS_DruwelLaurens.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Director { get; set; }
        public int Stars { get; set; }
        public ICollection<ActorViewModel> Actors { get; set; }

    }
}
