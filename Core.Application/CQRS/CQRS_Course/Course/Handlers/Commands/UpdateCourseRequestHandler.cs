using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Course.Requests.Commands;
using Core.Application.DTOs.Course.Course.Validators;
using MediatR;
using Core.Application.Exceptions;

namespace Core.Application.CQRS.CQRS_Course.Course.Handlers.Commands
{
    public class UpdateCourseRequestHandler : IRequestHandler<UpdateCourseRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _course;

        public UpdateCourseRequestHandler(ICourseRepository course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
        {

            var validator = new UpdateCourseDTOValidator();
            var validationResult = await validator.ValidateAsync(request.courseDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var courseOBJ = await _course.GetAsync(request.courseDTO.CourseId);
            _mapper.Map(request.courseDTO, courseOBJ);
            await _course.UpdateAsync(courseOBJ);
            return Unit.Value;
        }
    }
}
