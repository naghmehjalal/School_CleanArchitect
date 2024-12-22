using Core.Application.DTOs.Course.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Queries
{
    public class GetCommentByIdRequest : IRequest<CommentDTO>
    {
        public int commentId { get; set; }
    }
}
