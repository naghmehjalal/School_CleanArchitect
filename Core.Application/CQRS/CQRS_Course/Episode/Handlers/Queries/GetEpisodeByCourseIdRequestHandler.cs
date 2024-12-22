using Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Queries;
using Core.Application.DTOs.Course.Episod;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Handlers.Queries
{
    public class GetEpisodeByCourseIdRequestHandler : IRequestHandler<GetEpisodeByCourseIdRequest, List<EpisodeDTO>>
    {
        public Task<List<EpisodeDTO>> Handle(GetEpisodeByCourseIdRequest request, CancellationToken cancellationToken)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
