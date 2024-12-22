using Core.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Ent_Course
{
    public class Episode : BaseDomainEntity
    {

        [Key]
        public int EpisodeId { get; set; }


        [Display(Name = "عنوان بخش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string EpisodeTitle { get; set; }

        [Display(Name = "زمان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TimeSpan EpisodeTime { get; set; }

        //[Display(Name = "فایل")]
        //public string EpisodeFileName { get; set; } = string.Empty;

        [Display(Name = "رایگان")]
        public bool IsFree { get; set; }

        #region Relation

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }


        #endregion

    }
}
