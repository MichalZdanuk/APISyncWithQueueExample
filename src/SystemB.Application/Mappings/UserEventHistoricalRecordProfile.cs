using AutoMapper;
using SystemB.Application.DTOs.UserEventHistoricalRecords;
using SystemB.Domain.Entities;

namespace SystemB.Application.Mappings
{
    public class UserEventHistoricalRecordProfile : Profile
    {
        public UserEventHistoricalRecordProfile()
        {
            CreateMap<UserEventHistoricalRecord, UserEventHistoricalRecordDto>();
        }
    }
}
