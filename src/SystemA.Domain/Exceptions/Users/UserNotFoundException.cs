using Shared.Exceptions;

namespace SystemA.Domain.Exceptions.Users
{
    public sealed class UserNotFoundException
        : NotFoundException
    {
        public UserNotFoundException(Guid userId) : base($"User with id: {userId} was not found.")
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
