using Core.Application.DTOs.Course.Course;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Course.Requests.Queries
{
    public class GetCourseByIdRequest : IRequest<CourseDTO>
    {
        public int Id { get; set; }
    }
  
}
