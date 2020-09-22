using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.ViewModel;

namespace CRUD.Controllers
{
    [Authorize(Roles = MyConstants.RoleAdmin)]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View("MovieList", movies);
        }

        public ActionResult Add()
        {
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);

            else
            {
                var movieToUpdate = _context.Movies.Single(m => m.Id == movie.Id);
                movieToUpdate.Name = movie.Name;
                movieToUpdate.GenreId = movie.GenreId;
                movieToUpdate.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToDelete == null)
                return HttpNotFound();

            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToEdit == null)
                return HttpNotFound();

            var viewModel = new MovieViewModel(movieToEdit)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}