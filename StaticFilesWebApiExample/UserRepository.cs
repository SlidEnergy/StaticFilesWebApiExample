namespace StaticFilesWebApiExample
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AvatarFileName { get; set; }
    }

    public class UserDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AvatarToken { get; set; }

        public UserDto(string id, string name, string avatarToken)
        {
            Id = id;
            Name = name;
            AvatarToken = avatarToken;
        }
    }

    public class UserRepository
    {
        public void SaveAvatar(string token)
        {

        }

        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "test",
                AvatarFileName = $"{Guid.NewGuid().ToString()}.png"
            };
        }
    }
}
