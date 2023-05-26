using dotNetStudy.Data;
using dotNetStudy.Dtos;
using dotNetStudy.Models;

namespace dotNetStudy.Services
{
    public class UserService
    {
        private readonly AriaContext _context;

        public UserService(AriaContext context)
        {
            _context = context;
        }

        public List<UserReadDto> GetAllUsers()
        {
            var users = _context.Users.ToList();

            return users.Select(user => new UserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
                // Include other properties as needed...
            }).ToList();
        }

        public UserReadDto GetUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            return new UserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
                // Include other properties as needed...
            };
        }

        public UserReadDto CreateUser(UserCreateDto userCreateDto)
        {
            var newUser = new User
            {
                Name = userCreateDto.Name,
                Email = userCreateDto.Email
                // Include other properties as needed...
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return new UserReadDto
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email
                // Include other properties as needed...
            };
        }

        public UserReadDto UpdateUser(int id, UserUpdateDto updatedUserDto)
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

            return new UserReadDto
            {
                Id = existingUser.Id,
                Name = existingUser.Name,
                Email = existingUser.Email
                // Include other properties as needed...
            };
        }

        public UserReadDto DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return new UserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
                // Include other properties as needed...
            };
        }
    }
}

