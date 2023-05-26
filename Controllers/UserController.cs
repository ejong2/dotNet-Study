using dotNetStudy.Data;
using dotNetStudy.Dtos;
using dotNetStudy.Models;
using dotNetStudy.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotNetStudy.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<ApiResponse<List<User>>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(new ApiResponse<List<User>>
            {
                IsSuccessful = true,
                Data = users
            });
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<User>> GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound(new ApiResponse<User>
                {
                    IsSuccessful = false,
                    Message = "User not found"
                });
            }
            return Ok(new ApiResponse<User>
            {
                IsSuccessful = true,
                Data = user
            });
        }

        [HttpPost]
        public ActionResult<ApiResponse<User>> CreateUser(User user)
        {
            var createdUser = _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, new ApiResponse<User>
            {
                IsSuccessful = true,
                Data = createdUser
            });
        }

        [HttpPut("{id}")]
        public ActionResult<ApiResponse<User>> UpdateUser(int id, UserUpdateDto updatedUserDto)
        {
            var user = _userService.UpdateUser(id, updatedUserDto);
            if (user == null)
            {
                return BadRequest(new ApiResponse<User>
                {
                    IsSuccessful = false,
                    Message = "Failed to update user"
                });
            }
            return Ok(new ApiResponse<User>
            {
                IsSuccessful = true,
                Data = user
            });
        }


        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<User>> DeleteUser(int id)
        {
            var user = _userService.DeleteUser(id);
            if (user == null)
            {
                return NotFound(new ApiResponse<User>
                {
                    IsSuccessful = false,
                    Message = "User not found"
                });
            }
            return Ok(new ApiResponse<User>
            {
                IsSuccessful = true,
                Data = user
            });
        }
    }
}