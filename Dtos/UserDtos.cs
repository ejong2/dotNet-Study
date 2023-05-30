namespace dotNetStudy.Dtos
{
    public class UserDtos
    {
        public class UserJoinDto
        {
            public string loginId { get; set; }
            public string password { get; set; }
        }

        public class UserLoginDto
        {
            public string loginId { get; set; }
            public string password { get; set; }
        }
    }
}
