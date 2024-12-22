using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Commands;
using Core.Application.DTOs.Course.Comment.Validators;
using Core.Application.Exceptions;
using MediatR;
using Core.Domain.Entities.Ent_Course;

namespace Core.Application.CQRS.CQRS_Course.CourseComment.Handlers.Commands
{
    public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, int>
    {

        private readonly IMapper _mapper;
        private readonly ICommentRepository _courseComment;
        public CreateCommentRequestHandler
            (ICommentRepository courseComment, IMapper mapper)
        {
            _courseComment = courseComment;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommentDTOValidator();
            var validationResult = await validator.ValidateAsync(request.createCommentDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);



            var newComment = _mapper.Map<Comment>(request.createCommentDTO);
            newComment = await _courseComment.AddAsync(newComment);
            return newComment.CourseId;
        }
    }
}
