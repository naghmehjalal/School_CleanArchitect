using FluentValidation;

namespace Core.Application.DTOs.Course.Course.Validators
{
    public class ICourseDTOValidator : AbstractValidator<ICourseDTO>
    {
        public ICourseDTOValidator()
        {
            RuleFor(r => r.CourseTitle)
               .MaximumLength(50).WithMessage("{PropertyName} خطا در")
               .NotNull().WithMessage("{PropertyName} خطا در")
               .NotEmpty().WithMessage("{PropertyName} خطا در");

            //RuleFor(r => r.CourseDescription)
            //   .MaximumLength(200).WithMessage("{PropertyName} خطا در")
            //   .NotNull().WithMessage("{PropertyName} خطا در")
            //   .NotEmpty().WithMessage("{PropertyName} خطا در");

        }
    }
}
