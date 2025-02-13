namespace FagDag.EfCore.Api.Services;

public interface IEpicEventsService
{
    Task<IEnumerable<EventDto>> GetAllEventsAsync();
    Task<EventDto> GetEventByIdAsync(Guid id);
    Task<IEnumerable<ParticipantsDto>> GetAllParticipantsAsync();

    Task<ParticipantsDto> GetParticipantByIdAsync(int id);
}
