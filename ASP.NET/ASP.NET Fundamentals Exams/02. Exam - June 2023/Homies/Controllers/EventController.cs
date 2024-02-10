using Homies.Core.Contracts;
using Homies.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService service;

        public EventController(IEventService _service)
        {
            this.service = _service;
        }

        public async Task<IActionResult> All()
        {
            var events = await service.GetAllEventsAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var eventDto = new CreateEventDto();
            eventDto.Types = await service.GetAllTypesAsync();

            return View(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEventDto eventDto)
        {
            await service.AddEventAsync(eventDto);
            eventDto.CreatedOn = DateTime.Now;

            return RedirectToAction("All");
        }
    }
}
