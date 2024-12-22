using Core.Application.DTOs.Course.Group;
using Core.Application.Responses;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Group.Requests.Commands
{
    public class UpdateGroupRequest : IRequest<BaseCommandResponse>
    {
        //public int groupId { get; set; }
        public UpdateCourseGroupDTO groupDTO { get; set; }
    }
}
