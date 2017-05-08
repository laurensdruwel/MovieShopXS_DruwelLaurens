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
    public class MoviesController : Controller
    {

        private MovieBaseContext db;
        public MoviesController(MovieBaseContext context)
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
                .Select(e => new MoviesViewModel
                {
                    Id = e.MovieId,
                    Title = e.Title,
                    Year = e.Year,
                    Description = e.Description,
                    Image = "",
                    Stars = e.Stars,
                    Director = $"{e.Director.FirstName} {e.Director.LastName}",
                    Actors = e.MovieActor.Select(ma => new ActorViewModel
                    {
                        Name = $"{ma.Actor.FirstName} {ma.Actor.LastName}"
                    }).ToList()
                })
                .ToList());


        }

        public IActionResult Year(string year)
        {

            if (!String.IsNullOrEmpty(year))
            {
                List<MoviesViewModel> movieList = db.Movie
                    .Where(e => e.Year == int.Parse(year))
                    .Select(e => new MoviesViewModel
                    {
                        Id = e.MovieId,
                        Title = e.Title,
                        Image = @"images/" + e.Title + ".jpg",
                        Year = e.Year,
                        Description = e.Description,
                        Stars = Convert.ToInt32(e.Stars),
                        Director = $"{e.Director.FirstName} {e.Director.LastName}",
                        Actors = e.MovieActor.Select(ma => new ActorViewModel
                        {
                            Name = $"{ma.Actor.FirstName} {ma.Actor.LastName}"
                        }).ToList()
                    })
                .ToList();

                if (movieList.Count == 0)
                    ViewData["Message"] = $"No movies for the year {year}";

                return View(movieList);

            }
            else
            {

                ViewData["Message"] = $"No year given!";
                return View(new List<MoviesViewModel>());
            }
        }

    }

}

