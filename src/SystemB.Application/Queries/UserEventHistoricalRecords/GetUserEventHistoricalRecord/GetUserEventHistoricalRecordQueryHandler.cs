using AutoMapper;
using MediatR;
using SystemB.Application.DTOs.UserEventHistoricalRecords;
using SystemB.Application.Repositories;

namespace SystemB.Application.Queries.UserEventHistoricalRecords.GetUserEventHistoricalRecord
{
    public class GetUserEventHistoricalRecordQueryHandler(IUserEventHistoricalRecordRepository userEventHistoricalRecordRepository,
        IMapper mapper)
        : IRequestHandler<GetUserEventHistoricalRecordQuery, IReadOnlyList<UserEventHistoricalRecordDto>>
    {
        public async Task<IReadOnlyList<UserEventHistoricalRecordDto>> Handle(GetUserEventHistoricalRecordQuery request, CancellationToken cancellationToken)
        {
            var userEvents = await userEventHistoricalRecordRepository.GetAllAsync();

            var userEventDtos = mapper.Map<IReadOnlyList<UserEventHistoricalRecordDto>>(userEvents);

            return userEventDtos;
        }
    }
}
