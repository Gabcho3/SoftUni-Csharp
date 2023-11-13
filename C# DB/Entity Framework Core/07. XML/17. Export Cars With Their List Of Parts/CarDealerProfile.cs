using _09._Import_Suppliers.DTOs.Import;
using _10._Import_Parts.DTOs.Import;
using _11._Import_Cars.DTOs.Import;
using _12._Import_Customers.DTOs.Import;
using _13._Import_Sales.DTOs.Import;
using _14._Export_Cars_With_Distance.DTOs.Export;
using _15._Export_Cars_From_Make_BMW.DTOs.Export;
using _16._Export_Local_Suppliers.DTOs.Export;
using _17._Export_Cars_With_Their_List_Of_Parts.DTOs.Export;
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

            //Cars
            CreateMap<ImportCarsDTO, Car>();

            //Customers
            CreateMap<ImportCustomersDTO, Customer>();

            //Cars
            CreateMap<ImportSalesDTO, Sale>();

            //Export Cars
            CreateMap<Car, ExportCarsDTO>();
            CreateMap<Car, ExportSpecificCarsMake>();
            CreateMap<Car, ExportCarsWithPartsDTO>()
                .ForMember(dest => dest.Parts,
                    opt 
                        => opt.MapFrom(src => src.PartsCars
                            .Select(pc => pc.Part)
                            .OrderByDescending(p => p.Price)
                            .ToArray()));

            //Export Suppliers
            CreateMap<Supplier, ExportSuppliers>()
                .ForMember(dest => dest.PartsCount,
                    opt => opt.MapFrom(src => src.Parts.Count));

            //Export Parts
            CreateMap<Part, ExportPartsDTO>();
        }
    }
}
