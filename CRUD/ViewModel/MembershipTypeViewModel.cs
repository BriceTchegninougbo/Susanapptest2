using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models;

namespace CRUD.ViewModel
{
    public class MembershipTypeViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Discount Rate")]
        public int? DiscountRate { get; set; }

        [Display(Name = "Sign Up Fee")]
        public int? SignUpFee { get; set; }

        [Display(Name = "Duration in Months")]
        public int? DurationInMonths { get; set; }

        public string Label => Id != 0 ? "Edit Membership Type" : "Add Membership Type";

        public MembershipTypeViewModel()
        {
            Id = 0;
        }

        public MembershipTypeViewModel(MembershipType membershipType)
        {
            Id = membershipType.Id;
            Name = membershipType.Name;
            SignUpFee = membershipType.SignUpFee;
            DurationInMonths = membershipType.DurationInMonths;
            DiscountRate = membershipType.DiscountRate;
        }
    }
}