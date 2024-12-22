using Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities.Ent_Course
{
    public class CourseStatus : BaseDomainEntity
    {
        public CourseStatus() { }
        public CourseStatus(int statusId, string statusTitle)
        {
            StatusId = statusId;
            StatusTitle = statusTitle;
        }


        [Key]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(150)]
        public string StatusTitle { get; set; } = string.Empty;

        public ICollection<Course> course { get; set; }
      = new List<Course>();

    }
}
