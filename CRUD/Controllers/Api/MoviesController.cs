using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUD.Models;

namespace CRUD.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include(m => m.Genre);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = _context.Movies.Where(m => m.Name.Contains(query));

            var movies = moviesQuery.ToList();

            return Ok(movies);
        }
    }
}
