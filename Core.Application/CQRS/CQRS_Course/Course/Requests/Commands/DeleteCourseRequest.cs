using Core.Application.DTOs.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.Course.Requests.Commands
{
    public class DeleteCourseRequest : IRequest<Unit>
    {
        public int id { get; set; }
    }
}
