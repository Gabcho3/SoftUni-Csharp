using _09._Import_Suppliers.DTOs.Import;
using _10._Import_Parts.DTOs.Import;
using _11._Import_Cars.DTOs.Import;
using _12._Import_Customers.DTOs.Import;
using _13._Import_Sales.DTOs.Import;
using _14._Export_Cars_With_Distance.DTOs.Export;
using _15._Export_Cars_From_Make_BMW.DTOs.Export;
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
        }
    }
}
