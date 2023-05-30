using dotNetStudy.Data;
using dotNetStudy.Models;

namespace dotNetStudy.TestClass
{
    public class TestUserService
    {
        private readonly AriaContext _context;

        public TestUserService(AriaContext context)
        {
            _context = context;
        }

        public List<TestUserReadDto> GetAllUsers()
        {
            var users = _context.TestUsers.ToList();

            return users.Select(user => new TestUserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
                // Include other properties as needed...
            }).ToList();
        }

        public TestUserReadDto GetUser(int id)
        {
            var user = _context.TestUsers.Find(id);

            if (user == null)
            {
                return null;
            }

            return new TestUserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
                // Include other properties as needed...
            };
        }

        public TestUserReadDto CreateUser(TestUserCreateDto userCreateDto)
        {
            var newUser = new TestUser
            {
                Name = userCreateDto.Name,
                Email = userCreateDto.Email
                // Include other properties as needed...
            };

            _context.TestUsers.Add(newUser);
            _context.SaveChanges();

            return new TestUserReadDto
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email
                // Include other properties as needed...
            };
        }

        public TestUserReadDto UpdateUser(int id, TestUserUpdateDto updatedUserDto)
        {
            var existingUser = _context.TestUsers.Find(id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = updatedUserDto.Name;
            existingUser.Email = updatedUserDto.Email;
            // Update other properties as needed...

            _context.SaveChanges();

            return new TestUserReadDto
            {
                Id = existingUser.Id,
                Name = existingUser.Name,
                Email = existingUser.Email
                // Include other properties as needed...
            };
        }

        public TestUserReadDto DeleteUser(int id)
        {
            var user = _context.TestUsers.Find(id);

            if (user == null)
            {
                return null;
            }

            _context.TestUsers.Remove(user);
            _context.SaveChanges();

            return new TestUserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
                // Include other properties as needed...
            };
        }
    }
}

