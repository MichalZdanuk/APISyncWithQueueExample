namespace SystemA.Application.DTOs.Users
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
