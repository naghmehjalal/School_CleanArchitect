using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Commands;
using Core.Application.DTOs.Course.Comment.Validators;
using Core.Application.Exceptions;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Handlers.Commands
{
    public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _courseComment;
        public UpdateCommentRequestHandler
            (ICommentRepository courseComment, IMapper mapper)
        {
            _courseComment = courseComment;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {

            var validator = new UpdateCommentDTOValidator();
            var validationResult = await validator.ValidateAsync(request.updateCommentDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var courseOBJ = await _courseComment.GetAsync(request.updateCommentDTO.CommentId);
            _mapper.Map(request.updateCommentDTO, courseOBJ);
            await _courseComment.UpdateAsync(courseOBJ);
            return Unit.Value;
        }
    }
}
