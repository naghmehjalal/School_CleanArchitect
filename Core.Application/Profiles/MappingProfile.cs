using AutoMapper;
using Core.Application.DTOs.Course.Comment;
using Core.Application.DTOs.Course.Course;
using Core.Application.DTOs.Course.Episod;
using Core.Application.DTOs.Course.Group;
using Core.Application.DTOs.Course.Level;
using Core.Application.DTOs.Course.Status;
using Core.Application.DTOs.Users;
using Core.Application.DTOs.Wallet;
using Core.Domain.Entities.Ent_Course;
using Core.Domain.Entities.Ent_Wallet;
using Infrastructure.Identity.Models;

namespace Core.Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            #region Course

            CreateMap<Course, CreateCourseDTO>().ReverseMap();
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();

            CreateMap<CourseGroup, CreateCourseGroupDTO>().ReverseMap();
            CreateMap<CourseGroup, UpdateCourseGroupDTO>().ReverseMap();
            CreateMap<CourseGroup, CourseGroupDTO>().ReverseMap();

            CreateMap<CourseLevel, CourseLevelDTO>().ReverseMap();

            CreateMap<CourseStatus, CourseStatusDTO>().ReverseMap();

            CreateMap<Episode, EpisodeDTO>().ReverseMap();
            CreateMap<Episode, CreateEpisodeDTO>().ReverseMap();
            CreateMap<Episode, UpdateEpisodeDTO>().ReverseMap();

           // CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Comment, CreateCommentDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentDTO>().ReverseMap();

            CreateMap<ApplicationUser,UserDTO>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserDTO>().ReverseMap();

            CreateMap<ApplicationRole,RoleDTO>().ReverseMap();

            #endregion

            #region Order


            #endregion

            #region Wallet

            CreateMap<Wallet, WalletDTO>().ReverseMap();
            CreateMap<Wallet, CreateWalletDTO>().ReverseMap();
            CreateMap<Wallet, UpdateWalletDTO>().ReverseMap();

            #endregion
        }


    }
}
