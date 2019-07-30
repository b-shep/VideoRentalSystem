using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalSystem.Models;

namespace VideoRentalSystem.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/movies
        public JsonResponse getMovies()
        {
            JsonResponse jr = null;

            try
            {
                jr = JsonResponse.getInstance(_context.Movies.ToList());
            } catch (Exception e)
            {
                jr = JsonResponse.getInstance(e);
            }
            return jr;
        }

        //GET api/movies/{id}
        public JsonResponse getMovie(int id)
        {
            JsonResponse jr = null;

            try
            {
                var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
                if (movie == null)
                {
                    jr = JsonResponse.getInstance("Error: Movie with id=" + id + " not found.");
                    return jr;
                }
                jr = JsonResponse.getInstance(movie);
            } catch(Exception e)
            {
                jr = JsonResponse.getInstance(e);
            }

            return jr;
        }

        //POST api/movies
        public JsonResponse createMovie(Movie movie)
        {
            JsonResponse jr = null;

            try
            {
                var movieFromDb = _context.Movies.SingleOrDefault(m => m.Title == movie.Title &&  m.DateAdded == movie.DateAdded);
                if (movieFromDb == null)
                {
                    _context.Movies.Add(movie);
                    jr = JsonResponse.getInstance(_context.SaveChanges());
                }
                else
                {
                    jr = JsonResponse.getInstance("Error: Movie already exists in database.");
                }
            }
            catch (Exception e)
            {
                jr = JsonResponse.getInstance(e);
            }

            return jr;
        }

        //PUT api/movies/{id}
        public JsonResponse editMovie(Movie movie)
        {
            JsonResponse jr = null;

            try
            {
                var movieFromDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                if (movieFromDb == null)
                    jr = JsonResponse.getInstance("Error: attempting to edit movie with id=" + movie.Id + " cannot be found.");
                else
                {
                    movieFromDb.Title = movie.Title;
                    movieFromDb.GenreId = movie.GenreId;
                    movieFromDb.DateAdded = movie.DateAdded;
                    movieFromDb.NumberInStock = movie.NumberInStock;
                    movieFromDb.ReleaseDate = movie.ReleaseDate;

                    jr = JsonResponse.getInstance(_context.SaveChanges());
                }
            }
            catch (Exception e)
            {
                jr = JsonResponse.getInstance(e);
            }

            return jr;
        }

        //DELETE api/movies/{id}
        public JsonResponse deleteMovie(int id)
        {
            JsonResponse jr = null;

            return jr;
        }

    }
}
