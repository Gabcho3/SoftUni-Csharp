using System.Text;
using AutoMapper;
using Boardgames.Data.Models;
using Boardgames.DataProcessor.ImportDto;
using Boardgames.Utilities;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var creatorsDto = XmlHelper.Deserialize<ImportCreatorsDto[]>(xmlString, "Creators");
            var validCreatorsWithBoardGames = new HashSet<Creator>();

            StringBuilder sb = new StringBuilder();
            foreach (var creatorDto in creatorsDto)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                int boardGamesRemoved =
                    creatorDto.Boardgames.RemoveAll(b => !IsValid(b) || string.IsNullOrEmpty(b.Name));

                for (int i = 0; i < boardGamesRemoved; i++)
                {
                    sb.AppendLine("Invalid data!");
                }

                Creator creator = AutoMapper.Map<Creator>(creatorDto);
                validCreatorsWithBoardGames.Add(creator);

                sb.AppendLine(String.Format(SuccessfullyImportedCreator, 
                    creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreatorsWithBoardGames);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sellersDto = JsonConvert.DeserializeObject<ImportSellersDto[]>(jsonString);
            var allBoardgamesId = context.Boardgames.Select(b => b.Id);

            var validSellers = new HashSet<Seller>();

            StringBuilder sb = new StringBuilder();
            foreach (var sellerDto in sellersDto)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                int removedIds = sellerDto.BoardgamesId.RemoveWhere(id => !allBoardgamesId.Contains(id));
                for (int i = 0; i < removedIds; i++)
                {
                    sb.AppendLine("Invalid data!");
                }

                Seller seller = AutoMapper.Map<Seller>(sellerDto);

                foreach (var id in sellerDto.BoardgamesId)
                {
                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        BoardgameId = id
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                validSellers.Add(seller);

                sb.AppendLine(string.Format(SuccessfullyImportedSeller, 
                    seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static IMapper AutoMapper
            => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<BoardgamesProfile>();
        }));
    }
}
