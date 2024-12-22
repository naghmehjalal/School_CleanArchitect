using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.DTOs.Course.Group;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Group.Requests.Queries
{
    public class GetGroupsRequest :IRequest<List<CourseGroupDTO>>
    {

    }
}
