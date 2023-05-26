using dotNetStudy.Dtos;
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
        public ActionResult<ApiResponse<List<UserReadDto>>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(new ApiResponse<List<UserReadDto>>
            {
                IsSuccessful = true,
                Data = users
            });
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<UserReadDto>> GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound(new ApiResponse<UserReadDto>
                {
                    IsSuccessful = false,
                    Message = "User not found"
                });
            }
            return Ok(new ApiResponse<UserReadDto>
            {
                IsSuccessful = true,
                Data = user
            });
        }

        [HttpPost]
        public ActionResult<ApiResponse<UserReadDto>> CreateUser(UserCreateDto userCreateDto)
        {
            var createdUser = _userService.CreateUser(userCreateDto);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, new ApiResponse<UserReadDto>
            {
                IsSuccessful = true,
                Data = createdUser
            });
        }

        [HttpPut("{id}")]
        public ActionResult<ApiResponse<UserReadDto>> UpdateUser(int id, UserUpdateDto updatedUserDto)
        {
            var user = _userService.UpdateUser(id, updatedUserDto);
            if (user == null)
            {
                return BadRequest(new ApiResponse<UserReadDto>
                {
                    IsSuccessful = false,
                    Message = "Failed to update user"
                });
            }
            return Ok(new ApiResponse<UserReadDto>
            {
                IsSuccessful = true,
                Data = user
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<UserReadDto>> DeleteUser(int id)
        {
            var user = _userService.DeleteUser(id);
            if (user == null)
            {
                return NotFound(new ApiResponse<UserReadDto>
                {
                    IsSuccessful = false,
                    Message = "User not found"
                });
            }
            return Ok(new ApiResponse<UserReadDto>
            {
                IsSuccessful = true,
                Data = user
            });
        }
    }
}
