using Homies.Core.DTOs;

namespace Homies.Core.Contracts
{
    public interface IEventService
    {
        Task<List<TypeDto>> GetAllTypesAsync();

        Task<List<EventDto>> GetAllEventsAsync();

        Task<T> GetEventByIdAsync<T>(int id);

        Task<List<EventDto>> GetJoinedEventsAsync(string userId);

        Task AddEventAsync(EventFormDto eventDto);

        Task EditEventAsync(int id, EventFormDto eventDto);

        Task<bool> JoinEventAsync(int id, string userId);

        Task LeaveEventAsync(int id, string userId);
    }
}
