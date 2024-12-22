using Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Ent_Order
{
    public class UserDiscountCode
    {

        [Key]
        public int UD_Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("DiscountId")] 
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
