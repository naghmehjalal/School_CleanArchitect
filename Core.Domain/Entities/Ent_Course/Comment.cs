using Core.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Identity.Models; 

namespace Core.Domain.Entities.Ent_Course
{
    public class Comment : BaseDomainEntity
    {
        [Key]
        public int CommentId { get; set; }

        [MaxLength(700)]
        [Required]
        public string Comment_Text { get; set; } = string.Empty;
        public bool IsDelete { get; set; } = false;
        public bool IsAdminRead { get; set; } = false;


        #region Relation

        [Required]
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        //----------------------------------------------------


        [Required]
        [ForeignKey("UserId")]
        public int comment_UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        // public User.User User { get; set; }

        #endregion


    }
}
