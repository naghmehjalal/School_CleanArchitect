using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Group.Validators
{
    public class IGroupDTOValidator : AbstractValidator<ICourseGroupDTO>
    {
        public IGroupDTOValidator() 
        {
            RuleFor(r => r.GroupTitle)
                 .MaximumLength(50).WithMessage("کاراکتر  زیاد")
                 .NotNull().WithMessage(" پوچ نباشد ")
                 .NotEmpty().WithMessage("خالی نباشد");
                      
        }
    }
}
