using dotNetStudy.Services;
using Microsoft.AspNetCore.Mvc;
using static dotNetStudy.Dtos.UserDtos;

namespace dotNetStudy.Controllers
{
    [ApiController]
    [Route("api/v1/user/")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("join")]
        public ActionResult<int> Join(UserJoinDto userJoinDto)
        {
            try
            {
                var newUser = _userService.Create(userJoinDto);
                return CreatedAtAction(nameof(Join), new { id = newUser.Id }, newUser.Id);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPost("login")]
        public ActionResult<int> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = _userService.Login(userLoginDto);
                return Ok(new { userid = user.Id });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
