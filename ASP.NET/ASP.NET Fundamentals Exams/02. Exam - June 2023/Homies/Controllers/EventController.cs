using Homies.Core.Contracts;
using Homies.Core.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService service;
        private readonly UserManager<IdentityUser> userManager;

        public EventController(IEventService _service, UserManager<IdentityUser> _userManager)
        {
            this.service = _service;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> All()
        {
            var events = await service.GetAllEventsAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var eventDto = new EventFormDto
            {
                Types = await service.GetAllTypesAsync()
            };

            return View(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormDto eventDto)
        {
            eventDto.CreatedOn = DateTime.UtcNow;
            await service.AddEventAsync(eventDto);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventToEdit = await service.GetEventByIdAsync<EventFormDto>(id);
            eventToEdit.Types = await service.GetAllTypesAsync();

            return View(eventToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormDto eventDto)
        {
            await service.EditEventAsync(id, eventDto);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = userManager.GetUserId(User);
            var joinedEvents = await service.GetJoinedEventsAsync(userId);

            return View(joinedEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Joined(int id)
        {
            var userId = userManager.GetUserId(User);

            bool joined = await service.JoinEventAsync(id, userId);

            if (!joined)
            {
                return RedirectToAction("All");
            }

            var joinedEvents = await service.GetJoinedEventsAsync(userId);

            return View(joinedEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var userId = userManager.GetUserId(User);
            await service.LeaveEventAsync(id, userId);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var eventDto = await service.GetEventByIdAsync<EventDto>(id);

            return View(eventDto);
        }
    }
}
