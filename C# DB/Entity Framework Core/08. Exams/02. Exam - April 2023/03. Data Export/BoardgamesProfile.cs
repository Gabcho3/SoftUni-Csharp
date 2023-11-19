using Boardgames.Data.Models;
using Boardgames.DataProcessor.ImportDto;

namespace Boardgames
{
    using AutoMapper;

    public class BoardgamesProfile : Profile
    {
        // DO NOT CHANGE OR RENAME THIS CLASS!
        public BoardgamesProfile()
        {
            //Boardgames
            CreateMap<ImportBoardgamesDto, Boardgame>();

            //Creators
            CreateMap<ImportCreatorsDto, Creator>();

            //Sellers
            CreateMap<ImportSellersDto, Seller>();
        }
    }
}