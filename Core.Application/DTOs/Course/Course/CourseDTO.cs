using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Course
{
    public class CourseDTO 
    {
        public int CourseId { get; set; }
        public required string CourseTitle { get; set; }
        public string CourseDescription { get; set; } = string.Empty;
        public int CoursePrice { get; set; }
        public string Tags { get; set; } = string.Empty;
        public string CourseImageExtention { get; set; } = string.Empty;
        public string DemoFileExtention { get; set; } = string.Empty;

        public int LevelId { get; set; }
        public int StatusId { get; set; }
        public int GroupId { get; set; }

    }
}
