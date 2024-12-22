using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Episod.Validators
{
    public class CreateEpisodeDTOValidator :AbstractValidator<CreateEpisodeDTO>
    {
        public CreateEpisodeDTOValidator() 
        {
            Include(new IEpisodeDTOValidator());
        }

    }
}
