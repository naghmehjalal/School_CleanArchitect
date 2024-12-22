using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Group
{
    public interface ICourseGroupDTO
    {
        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
        public int? ParentId { get; set; }

    }
}
