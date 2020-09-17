using System.Linq;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.ViewModel;

namespace CRUD.Controllers
{
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Genres
        public ActionResult Index()
        {
            var genres = _context.Genres.ToList();

            return View(genres);
        }

        public ActionResult New()
        {
            return View("GenreForm", new GenreViewModel());
        }

        [HttpPost]
        public ActionResult Save(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GenreViewModel(genre);
               
                return View("GenreForm", viewModel);
            }

            if(genre.Id == 0)
                _context.Genres.Add(genre);

            else
            {
                var genreToUpdate = _context.Genres.Single(m => m.Id == genre.Id);
                genreToUpdate.Name = genre.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Genres");
        }

        public ActionResult Delete(int id)
        {
            var genreToDelete = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreToDelete == null)
                return HttpNotFound();

            _context.Genres.Remove(genreToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "Genres");

        }

        public ActionResult Edit(int id)
        {
            var genreToEdit = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreToEdit == null)
                return HttpNotFound();

            return View("GenreForm", new GenreViewModel(genreToEdit));
        }
    }
}