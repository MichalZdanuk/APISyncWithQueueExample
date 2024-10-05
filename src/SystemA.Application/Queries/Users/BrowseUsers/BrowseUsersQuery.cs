using MediatR;
using SystemA.Application.DTOs.Users;

namespace SystemA.Application.Queries.Users.BrowseUsers
{
    public record BrowseUsersQuery() : IRequest<IReadOnlyList<UserDto>>;
}
