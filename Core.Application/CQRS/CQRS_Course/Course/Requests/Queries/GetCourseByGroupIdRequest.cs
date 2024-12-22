using Core.Application.DTOs.Course.Course;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Course.Requests.Queries
{
    public class GetCourseByGroupIdRequest : IRequest<List<CourseDTO>>
    {
        public int GroupId { get; set; }
    }
}
