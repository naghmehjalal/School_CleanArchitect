using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Handlers.Commands
{
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, Unit>
    {
      
        private readonly ICommentRepository _courseComment;
        public DeleteCommentRequestHandler
            (ICommentRepository courseComment)
        {
            _courseComment = courseComment;
        }

        public async Task<Unit> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var commentOBJ = await _courseComment.GetAsync(request.commentId);
            await _courseComment.DeleteAsync(commentOBJ);
            return Unit.Value;
        }
    }
}
