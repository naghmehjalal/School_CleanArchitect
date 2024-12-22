using Core.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Ent_Course
{
    public class CourseGroup : BaseDomainEntity
    {

        public CourseGroup(int groupId, string groupTitle, int? parentId = null)
        {
            GroupId = groupId;
            GroupTitle = groupTitle;
            IsDelete = false;

            if (parentId != null )
                ParentId = parentId;
        }

        public CourseGroup()
        {  }

        [Key]
        public int GroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupTitle { get; set; }


        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }


        [Display(Name = "حذف شده ؟")]
        public bool IsDelete { get; set; }


        //---------------------------------------------------------------
        #region Relation

        [ForeignKey("ParentId")]
        public List<CourseGroup> CourseGroups { get; set; }
        //-------------------------------------
        public ICollection<Course> courses { get; set; }
       = new List<Course>();

        #endregion

    }
}
