using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalSystem.Models;
using VideoRentalSystem.ViewModels;

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
            var movies = _context.Movies.ToList();

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

 //       public ActionResult New




    }
}