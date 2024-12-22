using Core.Application.DTOs.Course.Group;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Group.Requests.Queries
{
    public class GetSubGroupRequest :IRequest<List<CourseGroupDTO>>
    {
        public int ParentId { get; set; }
    }
}
