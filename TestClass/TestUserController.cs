using Microsoft.AspNetCore.Mvc;

namespace dotNetStudy.TestClass
{
    [ApiController]
    [Route("api/test/users")]
    public class TestUserController : ControllerBase
    {
        private readonly TestUserService _userService;

        public TestUserController(TestUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<TestApiResponse<List<TestUserReadDto>>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(new TestApiResponse<List<TestUserReadDto>>
            {
                IsSuccessful = true,
                Data = users
            });
        }

        [HttpGet("{id}")]
        public ActionResult<TestApiResponse<TestUserReadDto>> GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound(new TestApiResponse<TestUserReadDto>
                {
                    IsSuccessful = false,
                    Message = "User not found"
                });
            }
            return Ok(new TestApiResponse<TestUserReadDto>
            {
                IsSuccessful = true,
                Data = user
            });
        }

        [HttpPost]
        public ActionResult<TestApiResponse<TestUserReadDto>> CreateUser(TestUserCreateDto userCreateDto)
        {
            var createdUser = _userService.CreateUser(userCreateDto);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, new TestApiResponse<TestUserReadDto>
            {
                IsSuccessful = true,
                Data = createdUser
            });
        }

        [HttpPut("{id}")]
        public ActionResult<TestApiResponse<TestUserReadDto>> UpdateUser(int id, TestUserUpdateDto updatedUserDto)
        {
            var user = _userService.UpdateUser(id, updatedUserDto);
            if (user == null)
            {
                return BadRequest(new TestApiResponse<TestUserReadDto>
                {
                    IsSuccessful = false,
                    Message = "Failed to update user"
                });
            }
            return Ok(new TestApiResponse<TestUserReadDto>
            {
                IsSuccessful = true,
                Data = user
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<TestApiResponse<TestUserReadDto>> DeleteUser(int id)
        {
            var user = _userService.DeleteUser(id);
            if (user == null)
            {
                return NotFound(new TestApiResponse<TestUserReadDto>
                {
                    IsSuccessful = false,
                    Message = "User not found"
                });
            }
            return Ok(new TestApiResponse<TestUserReadDto>
            {
                IsSuccessful = true,
                Data = user
            });
        }
    }
}
