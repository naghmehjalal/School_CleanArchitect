using Core.Application.DTOs.Course.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Commands
{
    public class CreateCommentRequest : IRequest<int>
    {
        public required CreateCommentDTO createCommentDTO { get; set; }
    }
}
