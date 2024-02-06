using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Core.Contracts;
using Web.Core.ViewModels;

namespace SoftUniBazar.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService adService;
        private readonly UserManager<IdentityUser> userManager;

        public AdController(IAdService _adService, UserManager<IdentityUser> _userManager)
        {
            this.adService = _adService;
            userManager = _userManager;
        }

        public async Task<IActionResult> All()
        {
            var ads = await adService.GetAllAdsAsync();

            return View(ads);
        }

        public async Task<IActionResult> Cart()
        {
            var buyersAds = await adService.GetAllAdsOfUserAsync(userManager.GetUserId(User));

            return View(buyersAds);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var ad = new CreateAdViewModel
            {
                Categories = await adService.GetAllCategoriesAsync()
            };

            return View(ad);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAdViewModel ad)
        {
            await adService.AddAdAsync(ad);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var adToEdit = await adService.GetAdByIdAsync(id);
            adToEdit.Categories = await adService.GetAllCategoriesAsync();

            return View(adToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateAdViewModel ad)
        {
            int id = ad.Id;
            await adService.EditAdAsync(id, ad);

            return RedirectToAction("All");
        }

        public IActionResult AddToCart(int id)
        {
            var successful = adService.AddAdToCart(id, userManager.GetUserId(User));

            if (!successful)
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            await adService.RemoveFromCartAsync(id, userManager.GetUserId(User));

            return RedirectToAction("All");
        }
    }
}
