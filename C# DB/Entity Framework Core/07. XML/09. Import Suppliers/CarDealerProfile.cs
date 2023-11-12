using _09._Import_Suppliers.DTOs.Import;
using AutoMapper;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            CreateMap<ImportSuppliersDTO, Supplier>();
        }
    }
}
