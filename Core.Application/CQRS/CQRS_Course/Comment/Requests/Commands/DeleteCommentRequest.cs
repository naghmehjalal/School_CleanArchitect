using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Commands
{
    public class DeleteCommentRequest : IRequest<Unit>
    {
        public int commentId { get; set; }
    }
}
