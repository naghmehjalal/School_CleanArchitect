using Core.Application.DTOs.Course.Comment;
using Core.Domain.Entities.Ent_Course;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Queries
{
    public class GetCommentByCourseIdRequest : IRequest<List<CommentDTO>>
    {
        public int courseId { get; set; }
    }
}
