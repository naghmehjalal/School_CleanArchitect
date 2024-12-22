using FluentValidation;

namespace Core.Application.DTOs.Course.Episod.Validators
{
    public class UpdateEpisodeDTOValidator : AbstractValidator<UpdateEpisodeDTO>
    {
        public UpdateEpisodeDTOValidator() 
        {
            Include(new IEpisodeDTOValidator());

            RuleFor(p => p.EpisodeId).NotNull()
             .WithMessage("{PropertyName} is required.");

        }
    }
}
