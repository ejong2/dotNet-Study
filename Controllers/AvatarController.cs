using dotNetStudy.Services;
using Microsoft.AspNetCore.Mvc;
using static dotNetStudy.Dtos.AvatarDtos;

namespace dotNetStudy.Controllers
{
    [ApiController]
    [Route("api/v1/avatar/")]
    public class AvatarController : ControllerBase
    {
        private readonly AvatarService _avatarService;

        public AvatarController(AvatarService avatarService)
        {
            _avatarService = avatarService;
        }

        [HttpPost("{userId}")]
        public ActionResult<long> Create(int userId, [FromBody] AvatarCreateDto avatarCreateDto)
        {
            try
            {
                var newAvatar = _avatarService.Create(avatarCreateDto, userId);
                return CreatedAtAction(nameof(Create), new { id = newAvatar.Id }, newAvatar.Id);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AvatarResponseDto> Get(long id)
        {
            try
            {
                var avatar = _avatarService.Get(id);
                return Ok(avatar);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
