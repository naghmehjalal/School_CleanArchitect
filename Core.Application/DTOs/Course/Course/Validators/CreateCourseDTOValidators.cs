using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Course.Validators
{
    public class CreateCourseDTOValidators : AbstractValidator<CreateCourseDTO>
    {

        public CreateCourseDTOValidators() 
        {

            Include(new ICourseDTOValidator());
        }
    }
}
