namespace SystemA.Domain.Entities
{
    public class User
    {
        private User() { }

        public static User Create(Guid Id, string UserName, string Email, DateTime DateOfBirth)
        {
            return new User()
            {
                Id = Id,
                UserName = UserName,
                Email = Email,
                DateOfBirth = DateOfBirth
            };
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
