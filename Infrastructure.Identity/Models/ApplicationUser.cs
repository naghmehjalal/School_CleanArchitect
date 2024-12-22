using Core.Domain.Entities.Ent_Course;
using Microsoft.AspNetCore.Identity;
using Core.Domain.Entities.Ent_Order;

namespace Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

      //  public virtual ICollection<Comment>? comment { get; set; }

        public virtual ICollection<Comment>? comment { get; set; }
          = new List<Comment>();

        public virtual ICollection<UserDiscountCode>? UserDiscountCodes { get; set; }
          = new List<UserDiscountCode>();
    }
}
