using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Queries;
using Core.Application.DTOs.Course.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Handlers.Queries
{
    public class GetCommentByIdRequestHandler : IRequestHandler<GetCommentByIdRequest, CommentDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _courseComment;
        public GetCommentByIdRequestHandler
            (ICommentRepository courseComment, IMapper mapper)
        {
            _courseComment = courseComment;
            _mapper = mapper;
        }

        public async Task<CommentDTO> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
        {
            var commentOBJ = await _courseComment.GetAsync(request.commentId);
            return _mapper.Map<CommentDTO>(commentOBJ);
        }
    }
}
