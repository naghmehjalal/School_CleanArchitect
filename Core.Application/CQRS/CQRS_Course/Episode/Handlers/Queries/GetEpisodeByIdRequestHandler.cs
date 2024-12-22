using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
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
    public class GetEpisodeByIdRequestHandler : IRequestHandler<GetEpisodeByIdRequest, EpisodeDTO>
    {

        private readonly IMapper _mapper;
        private readonly IEpisodeRepository  _courseEpisode;

        public GetEpisodeByIdRequestHandler(IEpisodeRepository courseEpisode, IMapper mapper)
        {
            _courseEpisode= courseEpisode;
            _mapper= mapper;
        }

        public async Task<EpisodeDTO> Handle(GetEpisodeByIdRequest request, CancellationToken cancellationToken)
        {
            var episodeOBJ = await _courseEpisode.GetAsync(request.id);
            return _mapper.Map<EpisodeDTO>(episodeOBJ);
           

        }
    }
}
