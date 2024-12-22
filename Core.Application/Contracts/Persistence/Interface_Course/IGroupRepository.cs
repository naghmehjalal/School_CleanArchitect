using Core.Application.DTOs.Course.Group;
using Core.Domain.Entities.Ent_Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Persistence.Interface_Course
{
    public interface ICourseGroupRepository : IGenericRepository<CourseGroup>
    {
        public Task<List<CourseGroup>> GetSubdGroup(int parentId);
    }
}
