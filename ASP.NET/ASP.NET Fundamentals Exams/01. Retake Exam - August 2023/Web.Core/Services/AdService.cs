using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using Web.Core.AutoMapper;
using Web.Core.Contracts;
using Web.Core.ViewModels;
using Web.Infrastructure.Models;

namespace Web.Core.Services
{
    public class AdService : IAdService
    {
        private readonly BazarDbContext context;

        private static IMapper autoMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<BazarProfile>();
        }));

        public AdService(BazarDbContext _context)
        {
            context = _context;
        }

        public async Task<CreateAdViewModel> GetAdByIdAsync(int id)
        {
            var ad = await context.Ads.FindAsync(id);
            CreateAdViewModel viewModel = autoMapper.Map<CreateAdViewModel>(ad);

            return viewModel;
        }

        public async Task<List<AdViewModel>> GetAllAdsAsync()
        {
            return await context.Ads
                .Include(x => x.Owner)
                .Include(x => x.Category)
                .Select(a => autoMapper.Map<AdViewModel>(a))
                .ToListAsync();
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<List<AdViewModel>> GetAllAdsOfUserAsync(string buyerId)
        {
            var adsIds = await context.AdsBuyers
                .Where(x => x.BuyerId == buyerId)
                .Select(x => x.AdId)
                .ToListAsync();

            return await context.Ads
                .Include(a => a.Owner)
                .Include(a => a.Category)
                .Where(a => adsIds.Contains(a.Id))
                .Select(a => autoMapper.Map<AdViewModel>(a))
                .ToListAsync();

        }

        public async Task AddAdAsync(CreateAdViewModel ad)
        {
            Ad adToAdd = autoMapper.Map<Ad>(ad);
            adToAdd.CreatedOn = DateTime.Now;

            await context.Ads.AddAsync(adToAdd);
            await context.SaveChangesAsync();
        }

        public async Task EditAdAsync(int id, CreateAdViewModel ad)
        {
            var adToEdit = await context.Ads.FindAsync(id);

            adToEdit!.Name = ad.Name;
            adToEdit.Description = ad.Description;
            adToEdit.ImageUrl = ad.ImageUrl;
            adToEdit.Price = ad.Price;
            adToEdit.CategoryId = ad.CategoryId;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAdAsync(int id)
        {
            var ad = await context.Ads.FindAsync(id);
            context.Ads.Remove(ad!);
            
            await context.SaveChangesAsync();
        }

        public bool AddAdToCart(int adId, string buyerId)
        {
            AdBuyer? alreadyExist = context.AdsBuyers.FirstOrDefault(x => x.AdId == adId && x.BuyerId == buyerId);

            if (alreadyExist != null)
            {
                return false;
            }

            context.AdsBuyers.Add(new AdBuyer()
            {
                AdId = adId,
                BuyerId = buyerId
            });

            context.SaveChanges();

            return true;
        }

        public async Task RemoveFromCartAsync(int adId, string buyerId)
        {
            var recordToRemove = await context.AdsBuyers.FirstAsync(x => x.AdId == adId && x.BuyerId == buyerId);

            context.AdsBuyers.Remove(recordToRemove);
            await context.SaveChangesAsync();
        }
    }
}
