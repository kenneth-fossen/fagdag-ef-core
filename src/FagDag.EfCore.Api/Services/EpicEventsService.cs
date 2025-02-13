using FagDag.EfCore.Database;

namespace FagDag.EfCore.Api.Services;

public class EpicEventsService(EpicEventsDbContext DbContext) : IEpicEventsService
{
    public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
    {
        IEnumerable<EventDto> list = [];
        return list;
    }

    public async Task<EventDto> GetEventByIdAsync(Guid id)
    {
        return new EventDto(Guid.NewGuid());
    }

    public async Task<IEnumerable<ParticipantsDto>> GetAllParticipantsAsync()
    {
        IEnumerable<ParticipantsDto> participants = [];
        return participants;
    }

    public async Task<ParticipantsDto> GetParticipantByIdAsync(int id)
    {
        return new ParticipantsDto(1);
    }
}
