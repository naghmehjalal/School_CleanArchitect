using FluentValidation;

namespace Core.Application.DTOs.Course.Comment.Validators
{
    public class UpdateCommentDTOValidator :AbstractValidator<UpdateCommentDTO>
    {
        public UpdateCommentDTOValidator()
        {
            Include(new ICommentDTOValidator());

            RuleFor(p => p.CommentId).NotNull()
               .WithMessage("{PropertyName} is required.");
        }
    }
}
