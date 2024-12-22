
namespace Core.Application.DTOs.Course.Comment
{
    public class CreateCommentDTO : ICommentDTO
    {
        public int CommentId { get; set; }
        public string Comment_Text { get; set; }
        public bool IsAdminRead { get; set; }
        public int CourseId { get; set; }
        public int comment_UserId { get; set; }
    }
}
