using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalSystem.Models;
using VideoRentalSystem.ViewModels;
using System.Data.Entity;
using System.Data.SqlTypes;

namespace VideoRentalSystem.Controllers
{

    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

      
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [Route("Movies/Index")]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }


        [Route("Movies/Detail/{id}")]
        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Movie movie)
        {

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                ModelState.Remove("movie.Id");
            }

            if (!ModelState.IsValid)
            {

                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList(),
                };
                if (movie.Id == 0)
                {
                    viewModel.New = true;
                }

                return View("MovieForm", viewModel);
            };


            if (movie.Id == 0) {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieFromDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieFromDB.Title = movie.Title;
                movieFromDB.GenreId = movie.GenreId;
                movieFromDB.DateAdded = movie.DateAdded;
                movieFromDB.ReleaseDate = movie.ReleaseDate;
                movieFromDB.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Route("Movies/New")]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
                New = true
            };

            return View("MovieForm", viewModel);
        }

        [Route("movies/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
                New = false,
                Movie = _context.Movies.Single(m => m.Id == id)
            };

            return View("MovieForm", viewModel);
        }

    }
}