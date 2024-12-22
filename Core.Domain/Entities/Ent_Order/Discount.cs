using Core.Domain.Entities.Ent_Course;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities.Ent_Order
{
    public class Discount
    {

        [Key]
        public int DiscountId { get; set; }


        [Display(Name = "کد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string DiscountCode { get; set; }

        [Display(Name = "درصد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int DiscountPercent { get; set; }

        public int? UsableCount { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public ICollection<UserDiscountCode> userDiscountCodes { get; set; }
 = new List<UserDiscountCode>();

    }
}
