using FagDag.EfCore.Database;

namespace FagDag.EfCore.Api.Services;

public class EpicEventsService(EpicEventsDbContext DbContext) : IEpicEventsService
{
    public async Task<IEnumerable<RaceDto>> GetAllRacesAsync()
    {
        IEnumerable<RaceDto> list = [];
        return list;
    }

    public async Task<IEnumerable<ParticipantsDto>> GetAllParticipantsAsync()
    {
        IEnumerable<ParticipantsDto> participants = [];
        return participants;
    }

    public async Task<ParticipantsDto> GetParticipantsAsync(int id)
    {
        return new ParticipantsDto();
    }
}

public interface IEpicEventsService
{
    Task<IEnumerable<RaceDto>> GetAllRacesAsync();
    Task<IEnumerable<ParticipantsDto>> GetAllParticipantsAsync();

    Task<ParticipantsDto> GetParticipantsAsync(int id);
}

public record ParticipantsDto;

public record RaceDto;
