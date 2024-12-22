using Core.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Domain.Entities.Ent_Course
{
    public class Course : BaseDomainEntity
    {

        [Key]
        public int CourseId { get; set; }

        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CourseTitle { get; set; } = string.Empty;

        [Display(Name = "شرح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseDescription { get; set; } = string.Empty;

        [Display(Name = "قیمت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CoursePrice { get; set; }

        [MaxLength(600)]
        public string? Tags { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? CourseImageExtention { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? DemoFileExtention { get; set; } = string.Empty;

        //----------------------------------------------
        #region Relation

        [Required]
        [ForeignKey("GroupId")]
        public int GroupId { get; set; }

        public CourseGroup? CourseGroup { get; set; }

        public ICollection<Episode> courseEpisodes { get; set; }
      = new List<Episode>();


        public ICollection<Comment> courseComments { get; set; }
      = new List<Comment>();


        [Required]
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        public CourseStatus? Status { get; set; }

        [Required]
        [ForeignKey("LevelId")]
        public int LevelId { get; set; }
        public CourseLevel? Level { get; set; }


        #endregion



    }
}
