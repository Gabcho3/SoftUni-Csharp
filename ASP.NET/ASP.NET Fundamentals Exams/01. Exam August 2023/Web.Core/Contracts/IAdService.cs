using Web.Core.ViewModels;

namespace Web.Core.Contracts
{
    public interface IAdService
    {
        Task<CreateAdViewModel> GetAdByIdAsync(int id);

        Task<List<AdViewModel>> GetAllAdsAsync();

        Task<List<CategoryViewModel>> GetAllCategoriesAsync();

        Task<List<AdViewModel>> GetAllAdsOfUserAsync(string buyerId);


        Task AddAdAsync(CreateAdViewModel ad);

        Task EditAdAsync(int id, CreateAdViewModel ad);

        bool AddAdToCart(int adId, string buyerId);

        Task RemoveFromCartAsync(int adId, string buyerId);
    }
}
