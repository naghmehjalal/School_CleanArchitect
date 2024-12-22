using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Course.Requests.Commands;
using Core.Application.DTOs.Course.Course.Validators;
using Core.Application.Exceptions;
using MediatR;
using Core.Domain.Entities.Ent_Course;


namespace Core.Application.CQRS.CQRS_Course.Course.Handlers.Commands
{
    public class CreateCourseRequestHandler : IRequestHandler<CreateCourseRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _course;
        public CreateCourseRequestHandler(ICourseRepository course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCourseDTOValidators();
            var validationResult = await validator.ValidateAsync(request.courseDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);


            var newCource = _mapper.Map<Core.Domain.Entities.Ent_Course.Course>(request.courseDTO);
            newCource = await _course.AddAsync(newCource);
            return newCource.CourseId;
        }
    }
}
