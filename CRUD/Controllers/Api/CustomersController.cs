using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using CRUD.Models;

namespace CRUD.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = _context.Customers.Where(c => c.FirstName.Contains(query));

            var customers = customersQuery.ToList();

            return Ok(customers);
        }
    }
}
