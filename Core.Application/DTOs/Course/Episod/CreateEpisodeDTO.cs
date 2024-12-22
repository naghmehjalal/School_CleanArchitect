using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Episod
{
    public class CreateEpisodeDTO : IEpisodeDTO
    {
        public int EpisodeId { get; set; }
        public required string EpisodeTitle { get; set; }
        public TimeSpan EpisodeTime { get; set; }

       public string EpisodeFileExtention { get; set; } = string.Empty;

        public bool IsFree { get; set; }
        public int CourseId { get; set; }
       
    }
}
