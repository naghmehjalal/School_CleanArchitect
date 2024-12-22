using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Commands;
using Core.Application.DTOs.Course.Episod.Validators;
using Core.Application.Exceptions;
using MediatR;
using Core.Domain.Entities.Ent_Course;


namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Handlers.Commands
{
    public class CreateEpisodRequestHandler : IRequestHandler<CreateEpisodRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IEpisodeRepository _courseEpisode;

        public CreateEpisodRequestHandler(IEpisodeRepository courseEpisode, IMapper mapper)
        {
            _courseEpisode = courseEpisode;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEpisodRequest request, CancellationToken cancellationToken)
        {

            var validator = new CreateEpisodeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.createEpisodeDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var newEpisod = _mapper.Map<Episode>(request.createEpisodeDTO);
            newEpisod = await _courseEpisode.AddAsync(newEpisod);
            return newEpisod.EpisodeId;
        }
    }
}
