using MediatR;
using SystemA.Application.DTOs.Users;

namespace SystemA.Application.Queries.Users.GetUser
{
    public record GetUserQuery(Guid Id) : IRequest<UserDto>;
}
