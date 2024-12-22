using FluentValidation;

namespace Core.Application.DTOs.Course.Comment.Validators
{
    public class CreateCommentDTOValidator :AbstractValidator<CreateCommentDTO>
    {
        public CreateCommentDTOValidator()
        {
             Include(new ICommentDTOValidator());
        }
       
    }
}
