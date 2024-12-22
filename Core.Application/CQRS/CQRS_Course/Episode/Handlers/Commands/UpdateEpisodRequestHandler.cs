using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Commands;
using Core.Application.DTOs.Course.Episod.Validators;
using Core.Application.Exceptions;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Handlers.Commands
{
    public class UpdateEpisodRequestHandler : IRequestHandler<UpdateEpisodRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEpisodeRepository _courseEpisode;
        public UpdateEpisodRequestHandler
            (IEpisodeRepository courseEpisode, IMapper mapper)
        {
            _courseEpisode = courseEpisode;
            _mapper = mapper;
        }

        public  async Task<Unit> Handle(UpdateEpisodRequest request, CancellationToken cancellationToken)
        {

            var validator = new UpdateEpisodeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateEpisodeDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var episodOBJ = await _courseEpisode.GetAsync(request.UpdateEpisodeDTO.EpisodeId);
            _mapper.Map(request.UpdateEpisodeDTO, episodOBJ);
            await _courseEpisode.UpdateAsync(episodOBJ);
            return Unit.Value;
        }
    }
}
