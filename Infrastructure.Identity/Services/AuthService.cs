using AutoMapper;
using Azure.Core;
using Core.Application.Constants;
using Core.Application.Contracts.Identity;
using Core.Application.DTOs.Users;
using Core.Application.Models.Identity;
using Core.Domain.Entities.Ent_Course;
using Infrastructure.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        #region User
        public async Task<RegistrationResponse> Register(RegisterationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
                throw new Exception($"user name '{request.UserName}' already exists.");


            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
                throw new Exception($"Email '{request.Email}' already exists.");

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Teacher");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
                throw new Exception($"{result.Errors}");
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception($"user with {request.Email} not fount.");

            // var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            //var result = await _signInManager.PasswordSignInAsync(
            //    user.UserName, request.Password, request.RememberMe, true);

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);


            if (!result.Succeeded)
                throw new Exception("رمزعبور یا نام کاربری اشتباه است");

            if (result.IsLockedOut)
                throw new Exception("اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیقه قفل شده است");

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new AuthResponse()
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
            };

            return response;

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomClaimTypes.Uid,user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            //var users = new List<UserDTO>();
            // users = await _userManager.Users
            //   .Select(u => new UserDTO()
            //   {
            //       Id = u.Id,
            //       UserName = u.UserName,
            //       LastName = u.LastName,
            //       FirstName = u.FirstName,
            //       Email=u.Email
            //   }).ToListAsync();
            //  return users;
            var users = await _userManager.Users.ToListAsync(); ;

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception($"user with not fount.");

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new Exception($"user with not fount.");

            return user;
        }

        public async Task<bool> ChangePasswordConfirmed(ApplicationUser user, string oldPassword, string newPassword)
        {
            // var hasher = new PasswordHasher<ApplicationUser>();
            //var oldPasswordHash = hasher.HashPassword(null, oldPassword);

            //if (oldPasswordHash != user.PasswordHash)
            //    throw new Exception($"old password is not correct.");


            var passwordValidator = new PasswordValidator<ApplicationUser>();
            var result = await passwordValidator.ValidateAsync(_userManager, user, newPassword).ConfigureAwait(false);

            if (result.Succeeded)
            {
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword).ConfigureAwait(false);
                if (!changePasswordResult.Succeeded)
                    throw new Exception("Could not change password!");

                return true;
            }
            else
            {
                var list = result.Errors.Select(x => x.Description).ToList();
                foreach (var error in list)
                {
                    //TODO  Log
                    //throw new Exception(result.Errors.Select(x => x.Description));
                    return false;
                }
            }

            //user.PasswordHash = hasher.HashPassword(null, newPassword);

            // var result = await _userManager.ChangePasswordAsync(user, usermodel.oldPassword, usermodel.newPassword);

            //important 
            //var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return false;
        }

        public async Task<bool> ChangePasswordConfirmed(string userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception($"user with not fount.");

            return await ChangePasswordConfirmed(user, oldPassword, newPassword);
        }

        public async Task<Unit> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var user = _mapper.Map<ApplicationUser>(updateUserDTO);
            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }

        public async Task<Unit> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new Exception($"user with not fount.");

            await DeleteUser(user);

            return Unit.Value;
        }

        public async Task<Unit> DeleteUser(ApplicationUser applicationUser)
        {
            await _userManager.DeleteAsync(applicationUser);

            return Unit.Value;
        }



        #endregion

        //================================================================================

        #region Roles
        public async Task<List<RoleDTO>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return _mapper.Map<List<RoleDTO>>(roles);
        }

        public async Task<RoleDTO> GetRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<string> CreateRole(RoleDTO role)
        {
                     
           var  appRole= _mapper.Map<RoleDTO, ApplicationRole>(role);

            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
                return appRole.Id;
            else
                throw new Exception($"{result.Errors}");
        }

        public async Task<Unit> UpdateRole(RoleDTO role)
        {
            var appRole = _mapper.Map<RoleDTO, ApplicationRole>(role);
            var result = await _roleManager.UpdateAsync(appRole);

            if (result.Succeeded)
                return Unit.Value;
            else
                throw new Exception($"{result.Errors}");
        }

        public async Task<Unit> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                throw new Exception("not found");
            else
                return Unit.Value;
        }

        Task<List<ApplicationRole>> IAuthService.GetRoles()
        {
            throw new NotImplementedException();
        }

        Task<ApplicationRole> IAuthService.GetRole(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateRole(ApplicationRole role)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> UpdateRole(ApplicationRole role)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}



