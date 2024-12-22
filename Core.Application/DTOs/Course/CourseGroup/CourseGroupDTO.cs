using Core.Application.DTOs.Course.Group;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Group
{
    public class CourseGroupDTO : ICourseGroupDTO
    {
        public  required int GroupId { get; set; }
        public required string GroupTitle { get; set; }
        
        public int? ParentId { get; set; }

    }
}
