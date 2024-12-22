using Core.Application.DTOs.Course.Episod;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Commands
{
    public class CreateEpisodRequest :IRequest<int>
    {
        public CreateEpisodeDTO createEpisodeDTO { get; set; }

    }
}
