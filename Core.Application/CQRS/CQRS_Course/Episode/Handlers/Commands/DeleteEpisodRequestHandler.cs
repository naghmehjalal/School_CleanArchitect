using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Commands;
using Core.Domain.Entities.Ent_Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Handlers.Commands
{
    public class DeleteEpisodRequestHandler : IRequestHandler<DeleteEpisodRequest, Unit>
    {
        private readonly IEpisodeRepository _courseEpisode;

        public DeleteEpisodRequestHandler(IEpisodeRepository courseEpisode)
        {
            _courseEpisode = courseEpisode;
        }

       
        public async Task<Unit> Handle(DeleteEpisodRequest request, CancellationToken cancellationToken)
        {
            var episodeOBJ = await _courseEpisode.GetAsync(request.id);
            await _courseEpisode.DeleteAsync(episodeOBJ);
            return Unit.Value;
        }
    }
}
