using Core.Application.DTOs.Course.Level;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseLevel.Requests.Queries
{
    public class GetCourseLevelRequest : IRequest<List<CourseLevelDTO>>
    {

    }
}
