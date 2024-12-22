using Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities.Ent_Course
{
    public class CourseLevel : BaseDomainEntity
    {
        public CourseLevel()
        {

        }

        public CourseLevel(int levelId, string levelTitle)
        {
            LevelId = levelId;
            LevelTitle = levelTitle;
        }

        [Key]
        public int LevelId { get; set; }

        [MaxLength(150)]
        [Required]
        public string LevelTitle { get; set; } = string.Empty;

        public ICollection<Course> course { get; set; }
     = new List<Course>();


    }
}
