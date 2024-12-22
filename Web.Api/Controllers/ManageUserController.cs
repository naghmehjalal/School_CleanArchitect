using Core.Application.Contracts.Identity;
using Core.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MediatR;
using static Web.Api.Controllers.CourseController;
using Core.Application.DTOs.Users;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : ControllerBase
    {

        private readonly IAuthService _authService;

        public ManageUserController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterationRequest request)
        {
            return Ok(await _authService.Register(request));
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<ApplicationUser>>> GetUsers()
        {
            return Ok(await _authService.GetUsers());
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<List<ApplicationUser>>> GetUser(string userId)
        {
            return Ok(await _authService.GetUser(userId));
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult<bool>> ChangePassword(string userId,string oldPassword , string newPassword)
        {
            return Ok( await _authService.ChangePasswordConfirmed(userId,oldPassword,newPassword)); 

        }
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put([FromForm] UpdateUserDTO updateUserDTO)
        //{
        //    await _authService.UpdateUser(updateUserDTO);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _authService.DeleteUser(id);

            return NoContent();
        }
    }
}
