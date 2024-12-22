using Core.Application.DTOs.Course.Comment;
using Core.Domain.Entities.Ent_Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Commands
{
    public class UpdateCommentRequest : IRequest<Unit>
    {
        public required UpdateCommentDTO updateCommentDTO { get; set; }
    }
}
