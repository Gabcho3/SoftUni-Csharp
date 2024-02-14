using Homies.Core.Contracts;
using Homies.Models.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService service;
        private readonly UserManager<IdentityUser> userManager;

        public EventController(IEventService _service, UserManager<IdentityUser> _userManager)
        {
            this.service = _service;
            this.userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allEvents = await service.GetEventsAsync();

            return View(allEvents);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventFormViewModel eventForm = new EventFormViewModel()
            {
                Types = await service.GetTypesAsync()
            };

            return View(eventForm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel eventForm)
        {
            eventForm.OrganiserId = GetUserId();

            await service.AddEventAsync(eventForm);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventForm = await service.GetEventByIdAsync(id);
            eventForm.Types = await service.GetTypesAsync();

            return View(eventForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormViewModel eventForm)
        {
            await service.EditEventAsync(id, eventForm);

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            try
            {
                await service.JoinEventAsync(id, GetUserId());
            }
            catch
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("Joined");
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var joinedEvents = await service.GetAllUsersEventsAsync(GetUserId());

            return View(joinedEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            await service.LeaveEventAsync(id, GetUserId());

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var eventViewModel = await service.GetEventDetailsAsync(id);

            return View(eventViewModel);
        }

        private string GetUserId() => userManager.GetUserId(User);
    }
}
