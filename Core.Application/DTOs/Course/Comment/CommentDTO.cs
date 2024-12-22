namespace Core.Application.DTOs.Course.Comment
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public required string Comment { get; set; }
        public bool IsAdminRead { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public int UserId { get; set; }
        public string FullUserName { get; set; } = string.Empty;
        public DateTime Created { get; set; }

    }
}
