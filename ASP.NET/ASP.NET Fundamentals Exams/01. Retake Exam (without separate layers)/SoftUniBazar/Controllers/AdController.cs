using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public AdController(BazarDbContext _context, UserManager<IdentityUser> _userManager)
        {
            this.context = _context;
            this.userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AdViewModel> ads = await context.Ads
                .AsNoTracking()
                .Select(a => new AdViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl,
                    CreatedOn = a.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Category = a.Category.Name,
                    Owner = a.Owner.UserName
                })
                .ToArrayAsync();

            return View(ads);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AdFormViewModel ad = new AdFormViewModel()
            {
                Categories = await context.Categories
                    .AsNoTracking()
                    .Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToArrayAsync()
            };

            return View(ad);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel ad)
        {
            Ad adToAdd = new Ad()
            {
                Name = ad.Name,
                Description = ad.Description,
                Price = ad.Price,
                ImageUrl = ad.ImageUrl,
                CreatedOn = DateTime.UtcNow,
                CategoryId = ad.CategoryId,
                OwnerId = this.userManager.GetUserId(User)
            };

            await context.Ads.AddAsync(adToAdd);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Ad? ad = await context.Ads.FindAsync(id);

            AdFormViewModel adToEdit = new AdFormViewModel()
            {
                Name = ad!.Name,
                Description = ad.Description,
                Price = ad.Price,
                ImageUrl = ad.ImageUrl,
                CategoryId = ad.CategoryId,

                Categories = await context.Categories
                    .AsNoTracking()
                    .Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToArrayAsync()
            };

            return View(adToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdFormViewModel ad)
        {
            Ad? adToEdit = await context.Ads.FindAsync(id);

            adToEdit!.Name = ad!.Name;
            adToEdit.Description = ad.Description;
            adToEdit.Price = ad.Price;
            adToEdit.ImageUrl = ad.ImageUrl;
            adToEdit.CategoryId = ad.CategoryId;

            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            int[] allBuyersAdIds = await context.AdBuyers
                .AsNoTracking()
                .Where(x => x.BuyerId == userManager.GetUserId(User))
                .Select(x => x.AdId)
                .ToArrayAsync();

            IEnumerable<AdViewModel> ads = await context.Ads
                .AsNoTracking()
                .Where(a => allBuyersAdIds.Contains(a.Id))
                .Select(a => new AdViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl,
                    CreatedOn = a.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Category = a.Category.Name,
                    Owner = a.Owner.UserName
                })
                .ToArrayAsync();

            return View(ads);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            bool alreadyExist = context.AdBuyers
                .Any(x => x.AdId == id && x.BuyerId == userManager.GetUserId(User));

            if (alreadyExist)
            {
                return RedirectToAction("All");
            }

            await context.AdBuyers.AddAsync(new AdBuyer()
            {
                AdId = id,
                BuyerId = userManager.GetUserId(User)
            });

            await context.SaveChangesAsync();

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var entityToRemove = await context.AdBuyers
                .FirstAsync(x => x.AdId == id && x.BuyerId == userManager.GetUserId(User));

            context.AdBuyers.Remove(entityToRemove);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}
