using Core.Application.DTOs.Course.Episod;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Commands
{
    public class UpdateEpisodRequest : IRequest<Unit>
    {
        public required UpdateEpisodeDTO UpdateEpisodeDTO { get; set; }

    }
}
