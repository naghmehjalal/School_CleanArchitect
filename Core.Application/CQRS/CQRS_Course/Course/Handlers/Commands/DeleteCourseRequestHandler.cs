using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Course.Requests.Commands;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Course.Handlers.Commands
{
    public class DeleteCourseRequestHandler : IRequestHandler<DeleteCourseRequest, Unit>
    {
        private readonly ICourseRepository _course;
        public DeleteCourseRequestHandler(ICourseRepository course)
        {
            _course = course;
        }

        public async  Task<Unit> Handle(DeleteCourseRequest request, CancellationToken cancellationToken)
        {
            var courceOBJ = await _course.GetAsync(request.id);
            await _course.DeleteAsync(courceOBJ);
            return Unit.Value;
        }
    }
}
