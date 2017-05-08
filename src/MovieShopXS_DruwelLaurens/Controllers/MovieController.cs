using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieShopXS_DruwelLaurens.Entities;
using MovieShopXS_DruwelLaurens.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopXS_DruwelLaurens.Controllers
{
    public class MovieController : Controller
    {

        private MovieBaseContext db;
        public MovieController(MovieBaseContext context)
        {
            db = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(db.Movie
                .Select(e => new MovieViewModel
                {
                    Id = e.MovieId,
                    Title = e.Title,
                    Year = e.Year,
                    Description = e.Description,
                    Director = e.DirectorId,
                    Image = "",
                    Stars = e.Stars
                }));
            qdsfqsdf
       
    }
    }
}
