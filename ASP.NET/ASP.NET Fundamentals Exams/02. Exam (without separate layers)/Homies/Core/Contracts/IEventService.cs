using Homies.Models.Event;
using Homies.Models.Type;

namespace Homies.Core.Contracts
{
    public interface IEventService
    {
        Task<EventFormViewModel> GetEventByIdAsync(int id);

        Task<IEnumerable<EventAllViewModel>> GetEventsAsync();

        Task<IEnumerable<TypeViewModel>> GetTypesAsync();

        Task<IEnumerable<EventAllViewModel>> GetAllUsersEventsAsync(string helperId);

        Task AddEventAsync(EventFormViewModel eventForm);

        Task EditEventAsync(int id, EventFormViewModel eventForm);

        Task JoinEventAsync(int id, string helperId);

        Task LeaveEventAsync(int id, string helperId);

        Task<EventViewModel> GetEventDetailsAsync(int id);
    }
}
