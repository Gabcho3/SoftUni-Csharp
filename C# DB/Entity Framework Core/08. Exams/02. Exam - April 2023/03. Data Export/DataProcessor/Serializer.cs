using Boardgames.DataProcessor.ExportDto;
using Boardgames.Utilities;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using AutoMapper;
    using Boardgames.Data;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Count > 0)
                .Select(c => new ExportCreatorsDto()
                {
                    BoardGamesCount = c.Boardgames.Count,
                    Name = c.FirstName + " " + c.LastName,
                    Boardgames = c.Boardgames.Select(b => new ExportBoardgamesDto()
                        {
                            Name = b.Name,
                            YearPublished = b.YearPublished,
                        })
                        .OrderBy(b => b.Name)
                        .ToList()
                })
                .OrderByDescending(c => c.BoardGamesCount)
                .ThenBy(c => c.Name)
                .ToArray();

            return XmlHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(b => b.Boardgame.YearPublished >= year))
                .Where(s => s.BoardgamesSellers.Any(b => b.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year)
                        .Where(bs => bs.Boardgame.Rating <= rating)
                        .Select(bs => new
                        {
                            Name = bs.Boardgame.Name,
                            Rating = bs.Boardgame.Rating,
                            Mechanics = bs.Boardgame.Mechanics,
                            Category = bs.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(b => b.Rating)
                        .ThenBy(b => b.Name)
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Count())
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }

        private static IMapper AutoMapper
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BoardgamesProfile>();
            }));
    }
}