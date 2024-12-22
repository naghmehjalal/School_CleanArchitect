using Core.Application.DTOs.Course.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Group.Validators
{
    public class CreateGroupDTOValidator : AbstractValidator<CreateCourseGroupDTO>
    {

        public CreateGroupDTOValidator() 
        {
            Include(new IGroupDTOValidator());
        }
    }
}
