using Core.Application.DTOs.Course.Status;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseStatus.Requests.Queries
{
    public class GetCourseStatusRequest : IRequest<List<CourseStatusDTO>>
    {
    }
}
