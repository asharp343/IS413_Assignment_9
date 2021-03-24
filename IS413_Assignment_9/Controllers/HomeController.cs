using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IS413_Assignment_9.Models;
using IS413_Assignment_9.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IS413_Assignment_9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDBContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDBContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }


        // Display movie list
        [HttpGet]
        public IActionResult MovieList()
        {
            return View(new MovieListViewModel
            {
                Movies = context.Movies
            });
        }

        // Delete movie and redirect to movie list
        [HttpPost]
        public IActionResult DeleteMovie(int MovieId)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Remove(context.Movies.Find(MovieId));
                context.SaveChanges();
            }
            return View("MovieList", new MovieListViewModel
            {
                Movies = context.Movies
            });
        }

        // Displays add movie form
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        // Adds movie to context and db
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
                return View("MovieList", new MovieListViewModel
                {
                    Movies = context.Movies
                });
            }
            return View();
            
        }

        // Displays edit movie form
        [HttpGet]
        public IActionResult EditMovie(int MovieId)
        {
            return View("EditMovie", context.Movies.Find(MovieId));
        }

        // Saves edits to context and db
        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                context.Entry(movie).State = EntityState.Modified;
                context.SaveChanges();
            }
            return View("MovieList", new MovieListViewModel
            {
                Movies = context.Movies
            });
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
