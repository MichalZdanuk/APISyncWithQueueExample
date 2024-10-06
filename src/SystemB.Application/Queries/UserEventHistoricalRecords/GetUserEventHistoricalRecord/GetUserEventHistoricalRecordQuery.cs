using MediatR;
using SystemB.Application.DTOs.UserEventHistoricalRecords;

namespace SystemB.Application.Queries.UserEventHistoricalRecords.GetUserEventHistoricalRecord
{
    public record GetUserEventHistoricalRecordQuery() : IRequest<IReadOnlyList<UserEventHistoricalRecordDto>>;
}
