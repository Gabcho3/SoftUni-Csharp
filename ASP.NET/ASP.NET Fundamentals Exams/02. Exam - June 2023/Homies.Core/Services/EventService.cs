using AutoMapper;
using Homies.Core.AutoMapper;
using Homies.Core.Contracts;
using Homies.Core.DTOs;
using Homies.Data;
using Homies.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Core.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        private readonly IMapper autoMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<HomiesProfile>();
        }));

        public EventService(HomiesDbContext _context)
        {
            this.context = _context;
        }

        public async Task<List<TypeDto>> GetAllTypesAsync()
        {
            return await context.Types
                .Select(t => new TypeDto()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        public async Task<List<EventDto>> GetAllEventsAsync()
        {
            return await context.Events
                .Include(e => e.Organiser)
                .Include(e => e.Type)
                .Select(e => autoMapper.Map<EventDto>(e))
                .ToListAsync();
        }

        public async Task<T> GetEventByIdAsync<T>(int id)
        {
            var eventToEdit = await context.Events
                .Include(e => e.Organiser)
                .Include(e => e.Type)
                .FirstAsync(e => e.Id == id);

            return autoMapper.Map<T>(eventToEdit);
        }

        public async Task<List<EventDto>> GetJoinedEventsAsync(string userId)
        {
            var eventsIds = await context.EventsParticipants
                .Where(x => x.HelperId == userId)
                .Select(x => x.EventId)
                .ToListAsync();

            return await context.Events
                .Where(e => eventsIds.Contains(e.Id))
                .Select(e => autoMapper.Map<EventDto>(e))
                .ToListAsync();
        }

        public async Task AddEventAsync(EventFormDto eventDto)
        {
            var eventToAdd = autoMapper.Map<Event>(eventDto);

            await context.AddAsync(eventToAdd);
            await context.SaveChangesAsync();
        }

        public async Task EditEventAsync(int id, EventFormDto eventDto)
        {
            var eventToEdit = await context.Events.FindAsync(id);

            eventToEdit!.Name = eventDto.Name;
            eventToEdit.Description = eventDto.Description;
            eventToEdit.Start = eventDto.Start;
            eventToEdit.End = eventDto.End;
            eventToEdit.TypeId = eventDto.TypeId;

            await context.SaveChangesAsync();
        }

        public async Task<bool> JoinEventAsync(int id, string userId)
        {
            bool alreadyExist = context.EventsParticipants
                .Any(x => x.EventId == id && x.HelperId == userId);

            if (alreadyExist)
            {
                return false;
            }

            EventParticipant eventParticipant = new EventParticipant()
            {
                EventId = id,
                HelperId = userId
            };

            await context.EventsParticipants.AddAsync(eventParticipant);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task LeaveEventAsync(int id, string userId)
        {
            var recordToDelete = await context.EventsParticipants
                .FirstAsync(x => x.EventId == id && x.HelperId == userId);

            context.EventsParticipants.Remove(recordToDelete);

            await context.SaveChangesAsync();
        }
    }
}
