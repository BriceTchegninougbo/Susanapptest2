using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.ViewModel;

namespace CRUD.Controllers
{
    [Authorize(Roles = MyConstants.RoleAdmin)]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View("CustomerList", customers);
        }

        public ActionResult Add()
        {
            var viewModel = new CustomerViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerToUpdate = _context.Customers.Single(c => c.Id == customer.Id);
                customerToUpdate.FirstName = customer.FirstName;
                customerToUpdate.LastName = customer.LastName;
                customerToUpdate.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerToUpdate.Birthday = customer.Birthday;
                customerToUpdate.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customerToEdit = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToEdit == null)
                return HttpNotFound();

            var viewModel = new CustomerViewModel(customerToEdit)
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customerToDelete = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToDelete == null)
                return HttpNotFound();

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}