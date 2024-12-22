namespace WebApp.Models.CourseViewModels.CourseGroupViewModel
{
    public class UpdateCourseGroupVM
    {

        public required int GroupId { get; set; }
        public required string GroupTitle { get; set; }

        public int? ParentId { get; set; }
    }
}
