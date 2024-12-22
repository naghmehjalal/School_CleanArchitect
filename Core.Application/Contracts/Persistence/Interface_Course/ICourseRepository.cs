using Core.Application.DTOs.Course.Course;
using Core.Domain.Entities.Ent_Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Persistence.Interface_Course
{
    public interface ICourseRepository : IGenericRepository<Course>
    {

        public Task<List<Course>> GetCourseByGroupId(int groupId);
    }
}
