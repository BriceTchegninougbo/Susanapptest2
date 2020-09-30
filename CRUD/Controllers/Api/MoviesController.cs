using System.Data.Entity;
using System.Linq;
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
            var moviesQuery = _context.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = _context.Movies.Where(m => m.Name.Contains(query));

            var movies = moviesQuery.ToList();

            return Ok(movies);
        }
    }
}
