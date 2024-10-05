using AutoMapper;
using MediatR;
using SystemA.Application.DTOs.Users;
using SystemA.Application.Repositories;
using SystemA.Domain.Exceptions.Users;

namespace SystemA.Application.Queries.Users.GetUser
{
    public class GetUserQueryHandler(IUserRepository userRepository,
        IMapper mapper) : IRequestHandler<GetUserQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(query.Id);

            if(user is null)
            {
                throw new UserNotFoundException(query.Id);
            }

            var userDto = mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}
