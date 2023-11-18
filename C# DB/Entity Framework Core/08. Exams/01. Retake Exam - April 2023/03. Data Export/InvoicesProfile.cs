using AutoMapper;
using DataProcessor.ImportDto;
using Invoices.Data.Models;
using Invoices.DataProcessor.ImportDto;

namespace Invoices
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            //Clients
            CreateMap<ImportClientsDto, Client>();

            //Addresses
            CreateMap<ImportAddressesDto, Address>();

            //Invoices
            CreateMap<ImportInvoicesDto,  Invoice>();

            //Products
            CreateMap<ImportProductsDto, Product>();
        }
    }
}
