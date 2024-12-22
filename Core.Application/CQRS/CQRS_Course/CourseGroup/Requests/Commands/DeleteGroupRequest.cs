using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Group.Requests.Commands
{
    public class DeleteGroupRequest :IRequest<Unit>
    {
        public int groupId { get; set; }
    }
}
