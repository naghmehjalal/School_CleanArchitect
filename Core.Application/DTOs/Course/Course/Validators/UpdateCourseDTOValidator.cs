using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Course.Validators
{
    public class UpdateCourseDTOValidator :AbstractValidator<UpdateCourseDTO>
    {
        public UpdateCourseDTOValidator()
        {
            Include(new ICourseDTOValidator());

            RuleFor(p => p.CourseId).NotNull()
              .WithMessage("{PropertyName} is required.");
        }
    }
}
