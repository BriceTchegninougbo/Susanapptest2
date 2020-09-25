using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.ViewModel
{
    public class NewRentalViewModel
    {
        public int CustomerId { get; set; }

        public List<int> MovieIds { get; set; }
    }
}