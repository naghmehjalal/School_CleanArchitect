using FluentValidation;

namespace Core.Application.DTOs.Course.Group.Validators
{
    public class UpdateGroupDTOValidator : AbstractValidator<UpdateCourseGroupDTO>
    {
        public UpdateGroupDTOValidator() 
        {
            Include(new IGroupDTOValidator());

            RuleFor(p => p.GroupId).NotNull()
           .WithMessage("{PropertyName} is required.");
        }
    }
}
