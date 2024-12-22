using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Episod.Validators
{
    public class IEpisodeDTOValidator :AbstractValidator< IEpisodeDTO>
    {
        public IEpisodeDTOValidator() 
        {
            RuleFor(r => r.EpisodeTitle)
                  .MaximumLength(50).WithMessage("")
                  .NotNull().WithMessage("")
                  .NotEmpty().WithMessage("");

           RuleFor(r => r.CourseId)
            .NotNull().WithMessage("");


        }

    }
}
