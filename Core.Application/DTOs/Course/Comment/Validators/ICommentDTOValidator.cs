using FluentValidation;

namespace Core.Application.DTOs.Course.Comment.Validators
{
    public class ICommentDTOValidator : AbstractValidator<ICommentDTO>
    {
        public ICommentDTOValidator()
        {
            RuleFor(r => r.Comment_Text)
                .MaximumLength(200).WithMessage("")
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("");

            RuleFor(r => r.CourseId)
            .NotNull().WithMessage("");

        }
    }
}
