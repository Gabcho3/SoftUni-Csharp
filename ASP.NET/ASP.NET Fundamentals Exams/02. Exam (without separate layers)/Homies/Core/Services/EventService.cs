using Homies.Core.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Models.Type;
using Microsoft.EntityFrameworkCore;

namespace Homies.Core.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext _context)
        {
            this.context = _context;
        }

        public async Task<EventFormViewModel> GetEventByIdAsync(int id)
        {
            return await context.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new EventFormViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.TypeId,
                    OrganiserId = e.OrganiserId
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<EventAllViewModel>> GetEventsAsync()
        {
            return await context.Events
                .AsNoTracking()
                .Select(e => new EventAllViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToArrayAsync();
        }

        public async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
        {
            return await context.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel(t.Id, t.Name))
                .ToArrayAsync();
        }

        public async Task<IEnumerable<EventAllViewModel>> GetAllUsersEventsAsync(string helperId)
        {
            var allEventIds = context.EventsParticipants
                .AsNoTracking()
                .Where(e => e.HelperId == helperId)
                .Select(e => e.EventId);

            return await context.Events
                .AsNoTracking()
                .Where(e => allEventIds.Contains(e.Id))
                .Select(e => new EventAllViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Organiser = e.Organiser.UserName,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                })
                .ToArrayAsync();
        }

        public async Task AddEventAsync(EventFormViewModel eventForm)
        {
            Event eventToAdd = new Event()
            {
                Name = eventForm.Name,
                Description = eventForm.Description,
                CreatedOn = DateTime.Now,
                Start = eventForm.Start,
                End = eventForm.End,
                TypeId = eventForm.TypeId,
                OrganiserId = eventForm.OrganiserId
            };

            await context.Events.AddAsync(eventToAdd);
            await context.SaveChangesAsync();
        }

        public async Task EditEventAsync(int id, EventFormViewModel eventForm)
        {
            var eventToEdit = await context.Events.FindAsync(id);

            eventToEdit!.Name = eventForm.Name;
            eventToEdit.Description = eventForm.Description;
            eventToEdit.Start = eventForm.Start;
            eventToEdit.End = eventForm.End;
            eventToEdit.TypeId = eventForm.TypeId;

            await context.SaveChangesAsync();
        }

        public async Task JoinEventAsync(int id, string helperId)
        {
            await context.EventsParticipants.AddAsync(new EventParticipant()
            {
                EventId = id,
                HelperId = helperId
            });

            await context.SaveChangesAsync();
        }

        public async Task LeaveEventAsync(int id, string helperId)
        {
            var recordToDelete = await context.EventsParticipants
                .FirstAsync(x => x.EventId == id && x.HelperId == helperId);

            context.EventsParticipants.Remove(recordToDelete);

            await context.SaveChangesAsync();
        }

        public async Task<EventViewModel> GetEventDetailsAsync(int id)
        {
            return await context.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .FirstAsync();

        }
    }
}
