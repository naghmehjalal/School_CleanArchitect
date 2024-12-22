using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Course.Course
{
    public class UpdateCourseDTO :  ICourseDTO
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string? CourseDescription { get; set; }
        public int CoursePrice { get; set; }
        public string? Tags { get; set; }
        public string CourseImageExtention { get; set; } = string.Empty;
        public string DemoFileExtention { get; set; } = string.Empty;

        public int LevelId { get; set; }
        public int StatusId { get; set; }
        public int GroupId { get; set; }
    }
}
