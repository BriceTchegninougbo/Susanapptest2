using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? Birthday { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}