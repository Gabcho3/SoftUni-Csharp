using _02._Import_Products.DTOs.Import;
using _03._Import_Categories.DTOs.Import;
using AutoMapper;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User
            CreateMap<ImportUserDTO, User>();

            //Product
            CreateMap<ImportProductDTO, Product>();

            //Categories
            CreateMap<ImportCategoryDTO, Category>();
        }
    }
}
