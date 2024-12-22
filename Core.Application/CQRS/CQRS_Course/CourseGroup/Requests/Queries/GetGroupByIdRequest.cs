using Core.Application.DTOs.Course.Group;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Group.Requests.Queries
{
    public class GetGroupByIdRequest :IRequest<CourseGroupDTO>
    {
        public int Id { get; set; }
    }
}
