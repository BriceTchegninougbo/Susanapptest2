using System.Linq;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.ViewModel;

namespace CRUD.Controllers
{
    [Authorize(Roles = MyConstants.RoleAdmin)]
    public class MembershipTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MembershipTypes
        public ActionResult Index()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            return View("MembershipTypeList", membershipTypes);
        }

        public ActionResult Add()
        {
            return View("MembershipTypeForm", new MembershipTypeViewModel());
        }

        public ActionResult Save(MembershipType membershipType)
        {
            if (!ModelState.IsValid)
            {
                return View("MembershipTypeForm", new MembershipTypeViewModel(membershipType));
            }

            if (membershipType.Id == 0)
                _context.MembershipTypes.Add(membershipType);

            else
            {
                var membershipTypeToUpdate = _context.MembershipTypes.Single(m => m.Id == membershipType.Id);
                membershipTypeToUpdate.Name = membershipType.Name;
                membershipTypeToUpdate.DiscountRate = membershipType.DiscountRate;
                membershipTypeToUpdate.SignUpFee = membershipType.SignUpFee;
                membershipTypeToUpdate.DurationInMonths = membershipType.DurationInMonths;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "MembershipTypes");
        }

        public ActionResult Delete(int id)
        {
            var membershipTypeToDelete = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);

            if (membershipTypeToDelete == null)
                return HttpNotFound();

            _context.MembershipTypes.Remove(membershipTypeToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "MembershipTypes");
        }

        public ActionResult Edit(int id)
        {
            var membershipTypeToUpdate = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);

            if (membershipTypeToUpdate == null)
                return HttpNotFound();
            
            return View("MembershipTypeForm", new MembershipTypeViewModel(membershipTypeToUpdate));
        }
    }
}