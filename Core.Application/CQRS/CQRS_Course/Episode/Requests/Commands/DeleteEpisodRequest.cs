using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Commands
{
    public class DeleteEpisodRequest :IRequest<Unit>
    {
        public int id { get; set; }
    }
}
