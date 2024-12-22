using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Queries;
using Core.Application.DTOs.Course.Comment;
using MediatR;
using Core.Domain.Entities.Ent_Course;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Handlers.Queries
{
    public class GetCommentByCourseIdRequestHandler 
        : IRequestHandler<GetCommentByCourseIdRequest, List<CommentDTO>>
    {

        private readonly IMapper _mapper;
        private readonly ICommentRepository _courseComment;
        public GetCommentByCourseIdRequestHandler
            (ICommentRepository courseComment, IMapper mapper)
        {
            _courseComment = courseComment;
            _mapper = mapper;
        }

        public async Task<List<CommentDTO>> Handle(GetCommentByCourseIdRequest request, CancellationToken cancellationToken)
        {
            var obj = await _courseComment.GetByCourseId(request.courseId);

            return _mapper.Map<List<CommentDTO>>(obj);

        }
    }
}
