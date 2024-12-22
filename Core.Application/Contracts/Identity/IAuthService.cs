using Core.Application.DTOs.Users;
using Core.Application.Models.Identity;
using Infrastructure.Identity.Models;
using MediatR;

namespace Core.Application.Contracts.Identity
{
    public interface IAuthService
    {

        #region User
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegisterationRequest request);

        Task<List<UserDTO>> GetUsers();

        //Task<ApplicationUser> GetCurrentUser(); 

        Task<UserDTO> GetUser(string userId);

        Task<ApplicationUser> GetUserByEmail(string email);
        Task<bool> ChangePasswordConfirmed(string userId, string oldPassword, string newPassword);

        Task<bool> ChangePasswordConfirmed(ApplicationUser user, string oldPassword, string newPassword);
        Task<Unit> UpdateUser(UpdateUserDTO updateUserDTO);

        Task<Unit> DeleteUser(ApplicationUser applicationUser);

        Task<Unit> DeleteUser(string userId);
  

        #endregion


        #region Role
        Task <List<ApplicationRole>> GetRoles();
        Task<ApplicationRole> GetRole(string id);

        Task<string> CreateRole(ApplicationRole role);
        Task<Unit> UpdateRole(ApplicationRole role);
        Task<Unit> DeleteRole(string id);

        #endregion


    }
}
