using Homies.Core.DTOs;

namespace Homies.Core.Contracts
{
    public interface IEventService
    {
        Task<List<TypeDto>> GetAllTypesAsync();

        Task<List<EventDto>> GetAllEventsAsync();

        Task AddEventAsync(CreateEventDto eventDto);
    }
}
