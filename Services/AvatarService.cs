using dotNetStudy.Data;
using dotNetStudy.Models;
using static dotNetStudy.Dtos.AvatarDtos;

namespace dotNetStudy.Services
{
    public class AvatarService
    {
        private readonly AriaContext _context;

        public AvatarService(AriaContext context)
        {
            _context = context;
        }

        public Avatar Create(AvatarCreateDto avatarCreateDto, int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception($"해당 유저가 존재하지 않습니다. id={userId}");
            }

            var newAvatar = new Avatar
            {
                ChestIndexMale = avatarCreateDto.ChestIndexMale,
                FacesIndexMale = avatarCreateDto.FacesIndexMale,
                HairIndexMale = avatarCreateDto.HairIndexMale,
                LegsIndexMale = avatarCreateDto.LegsIndexMale,
                EyebrowIndexMale = avatarCreateDto.EyebrowIndexMale,
                HandsIndexMale = avatarCreateDto.HandsIndexMale,
                BeardIndexMale = avatarCreateDto.BeardIndexMale,
                IsMale = avatarCreateDto.IsMale,
                UserId = userId
            };

            _context.Avatars.Add(newAvatar);
            _context.SaveChanges();

            return newAvatar;
        }

        public AvatarResponseDto Get(long id)
        {
            var avatar = _context.Avatars.Find(id);

            if (avatar == null)
            {
                throw new Exception($"해당 아바타가 존재하지 않습니다. id={id}");
            }

            return new AvatarResponseDto
            {
                Id = avatar.Id,
                ChestIndexMale = avatar.ChestIndexMale,
                FacesIndexMale = avatar.FacesIndexMale,
                HairIndexMale = avatar.HairIndexMale,
                LegsIndexMale = avatar.LegsIndexMale,
                EyebrowIndexMale = avatar.EyebrowIndexMale,
                HandsIndexMale = avatar.HandsIndexMale,
                BeardIndexMale = avatar.BeardIndexMale,
                IsMale = avatar.IsMale
            };
        }
    }
}

