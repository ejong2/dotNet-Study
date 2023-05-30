using dotNetStudy.Data;
using dotNetStudy.Models;
using static dotNetStudy.Dtos.UserDtos;

namespace dotNetStudy.Services
{
    public class UserService
    {
        private readonly AriaContext _context;

        public UserService(AriaContext context)
        {   
            _context = context;
        }

        public User Create(UserJoinDto userJoinDto)
        {
            if (_context.Users.Any(u => u.loginId == userJoinDto.loginId))
            {
                throw new Exception("이미 존재하는 로그인 아이디입니다.");
            }

            var newUser = new User
            {
                loginId = userJoinDto.loginId,
                password = userJoinDto.password // You should hash this password in a real application
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public User Login(UserLoginDto userLoginDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.loginId == userLoginDto.loginId && u.password == userLoginDto.password);

            if (user == null)
            {
                throw new Exception("로그인 실패");
            }

            return user;
        }
    }
}
