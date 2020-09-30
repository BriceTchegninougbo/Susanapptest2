using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class RentPortalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentPortalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: RentPortal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RentalList()
        {
            var rentalList = _context.Rentals.Include(r => r.Customer).Include(r => r.Movie).ToList();

            return View(rentalList);
        }
    }
}