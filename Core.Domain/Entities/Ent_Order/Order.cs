using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Ent_Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int OrderSum { get; set; }
        public bool IsFinaly { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;


        #region Relation

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }
  = new List<OrderDetail>();

        #endregion

    }
}
