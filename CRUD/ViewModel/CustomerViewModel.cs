using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRUD.Models;

namespace CRUD.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            Id = 0;
        }

        public CustomerViewModel(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Birthday = customer.Birthday;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
        }
        public int? Id { get; set; }
        [Required][Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required][Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }

        [Display(Name = "Is Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public string Label => Id != 0 ? "Edit Customer" : "Add Customer";



    }
}