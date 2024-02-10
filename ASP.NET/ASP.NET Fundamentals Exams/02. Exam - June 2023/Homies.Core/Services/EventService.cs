using AutoMapper;
using Homies.Core.AutoMapper;
using Homies.Core.Contracts;
using Homies.Core.DTOs;
using Homies.Data;
using Homies.Infrastructure.Data.Models;
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

        public async Task AddEventAsync(CreateEventDto eventDto)
        {
            var eventToAdd = autoMapper.Map<Event>(eventDto);

            await context.AddAsync(eventToAdd);
            await context.SaveChangesAsync();
        }
    }
}
