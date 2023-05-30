namespace dotNetStudy.TestClass
{
    public class TestUserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // Add other properties as needed...

        // If there are any properties in the User entity that you don't want to expose to the client,
        // simply don't include them in this DTO.
    }

    public class TestUserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        // Add other properties as needed...

        // This DTO should include any properties that are required for creating a new user,
        // as well as any properties that the client should be able to set when creating a new user.
    }

    public class TestUserUpdateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        // Add other properties as needed...

        // This DTO should include any properties that the client should be able to update.
    }
}
