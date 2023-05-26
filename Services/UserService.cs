using dotNetStudy.Data;
using dotNetStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetStudy.Services
{
    public class UserService
    {
        private readonly AriaContext _context;

        public UserService(AriaContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(int id, UserUpdateDto updatedUserDto)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = updatedUserDto.Name;
            existingUser.Email = updatedUserDto.Email;
            // Update other properties as needed...

            _context.SaveChanges();

            return existingUser;
        }

        public User DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }
    }
}
