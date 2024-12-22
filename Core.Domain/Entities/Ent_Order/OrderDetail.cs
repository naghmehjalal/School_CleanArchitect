using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Ent_Order
{
    public  class OrderDetail
    { 
        
        public OrderDetail()
        {
            
        }

        public OrderDetail(int detailId,int courseId,int count, int price)
        {
            this.CourseId = courseId;
            this.DetailId = detailId;
            this.Count = count;
            this.Price = price;
        }


        [Key]
        public int DetailId { get; set; }
       
       
        [Required]
        public int Count { get; set; }
        
        [Required]
        public int Price { get; set; }

        #region Relation

        [Required]
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }


        [Required]
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        #endregion

    }
}
