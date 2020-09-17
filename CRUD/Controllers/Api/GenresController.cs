using System.Linq;
using System.Web.Http;
using CRUD.Models;

namespace CRUD.Controllers.Api
{
    public class GenresController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/genres
        [HttpGet]
        public IHttpActionResult GetGenres()
        {
            var genres = _context.Genres.ToList();

            return Ok(genres);
        }

        // GET/api/genres/id
        [HttpGet]
        public IHttpActionResult GetGenre(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (!ModelState.IsValid)
                return BadRequest();

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        // POST/api/genres
        [HttpPost]
        public IHttpActionResult CreateGenre(Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Genres.Add(genre);
            _context.SaveChanges();

            return Ok("Created!");
        }

        // PUT/api/genres/id
        public IHttpActionResult UpdateGenre(int id, Genre genre)
        {
            var genreToUpdate = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreToUpdate == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            genreToUpdate.Name = genre.Name;
            _context.SaveChanges();

            return Ok("Updated!");
        }

        // DELETE/api/genres/id
        public IHttpActionResult DeleteGenre(int id)
        {
            var genreToDelete = _context.Genres.SingleOrDefault(g => g.Id == id);

            if(genreToDelete == null)
                return NotFound();

            _context.Genres.Remove(genreToDelete);
            _context.SaveChanges();

            return Ok("Deleted!");
        }
    }
}
