using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> GetMovies() => new List<Movie>
        {
            new Movie { Id = 1, Name = "Shrek!" },
            new Movie { Id = 2, Name = "Wall-E" }
        };

        private List<Customer> GetCustomers() => new List<Customer>
        {
            new Customer { Id = 1, Name = "Customer 1" },
            new Customer { Id = 2, Name = "Customer 2" }
        };

        // GET: Movies
        [Route("movies")]
        public ActionResult Movies()
        {
            var movies = GetMovies();

            var viewModel = new MovieListViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }

        // GET: Movies/Details/id
        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var movies = GetMovies();

            var movie = movies.Find(m => m.Id == id);

            var customers = new List<Customer>();
            if (movie != null && movie.Name == "Shrek!")
            {
                customers = GetCustomers();
            }

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = GetCustomers();

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) {
                pageIndex = 1;
            }
            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}