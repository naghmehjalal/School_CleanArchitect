using Core.Application.DTOs.Course.Episod;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Queries
{
    public  class GetEpisodeByIdRequest :IRequest<EpisodeDTO>
    {
        public int id { get; set; }
    }
}
