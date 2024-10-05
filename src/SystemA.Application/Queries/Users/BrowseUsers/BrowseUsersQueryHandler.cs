using AutoMapper;
using MediatR;
using SystemA.Application.DTOs.Users;
using SystemA.Application.Repositories;

namespace SystemA.Application.Queries.Users.BrowseUsers
{
    public class BrowseUsersQueryHandler(IUserRepository userRepository,
        IMapper mapper)
        : IRequestHandler<BrowseUsersQuery, IReadOnlyList<UserDto>>
    {
        public async Task<IReadOnlyList<UserDto>> Handle(BrowseUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();

            var userDtos = mapper.Map<IReadOnlyList<UserDto>>(users);
            
            return userDtos;
        }
    }
}
