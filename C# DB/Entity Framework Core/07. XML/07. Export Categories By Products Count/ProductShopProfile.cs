using _02._Import_Products.DTOs.Import;
using _03._Import_Categories.DTOs.Import;
using _04._Import_Categories_and_Products.DTOs.Import;
using _05._Export_Products_In_Range.DTOs.Export;
using _06._Export_Sold_Products.DTOs;
using _06._Export_Sold_Products.DTOs.Export;
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
            CreateMap<Product, ExportProductDTO>()
                .ForMember(dest => dest.BuyerFullName,
                    opt =>
                        opt.MapFrom(src => src.Buyer.FirstName + ' ' + src.Buyer.LastName));
            CreateMap<Product, ProductDTO>();

            //Categories 
            CreateMap<ImportCategoryDTO, Category>();

            //CategoriesProducts
            CreateMap<ImportCategoryProductsDTO, CategoryProduct>();


        }
    }
}
