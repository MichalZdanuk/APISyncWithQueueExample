using AutoMapper;
using SystemA.Application.DTOs.Users;
using SystemA.Domain.Entities;

namespace SystemA.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
