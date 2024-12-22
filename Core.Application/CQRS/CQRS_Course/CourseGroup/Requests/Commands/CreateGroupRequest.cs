using Core.Application.DTOs.Course.Group;
using Core.Application.Responses;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Group.Requests.Commands
{
    public class CreateGroupRequest :IRequest<BaseCommandResponse>
    {
        public CreateCourseGroupDTO groupDTO { get; set; }
    }
}
