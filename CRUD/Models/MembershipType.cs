using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DiscountRate { get; set; }

        public int SignUpFee { get; set; }

        public int DurationInMonths { get; set; }



    }
}