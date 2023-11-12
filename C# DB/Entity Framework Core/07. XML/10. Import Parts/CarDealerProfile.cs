using _09._Import_Suppliers.DTOs.Import;
using _10._Import_Parts.DTOs.Import;
using AutoMapper;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Suppliers
            CreateMap<ImportSuppliersDTO, Supplier>();

            //Parts
            CreateMap<ImportPartsDTO, Part>();
        }
    }
}
