using Core.Application.DTOs.Course.Comment;
using Core.Domain.Entities.Ent_Course;

namespace Core.Application.Contracts.Persistence.Interface_Course
{
    public interface ICommentRepository :IGenericRepository<Comment>
    {

        public Task<List<CommentDTO>> GetByCourseId(int Courseid);
    }
}
