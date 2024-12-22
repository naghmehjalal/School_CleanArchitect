using Core.Application.DTOs.Course.Episod;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Queries
{
    public class GetEpisodeByCourseIdRequest : IRequest <List<EpisodeDTO>>
    {
        public int CourseId { get; set; }
    }
}
