using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths = new BoothRepository();
        private  List<string> allAvailableTypes = Assembly.GetExecutingAssembly().GetExportedTypes()
                .Where(t => t.IsClass && (t.Namespace == "ChristmasPastryShop.Models.Delicacies"
                || t.Namespace == "ChristmasPastryShop.Models.Cocktails")).Select(t => t.Name).ToList();
        private List<string> coctailSizes = new List<string>() { "Small", "Middle", "Large" };

        public string AddBooth(int capacity)
        {
            Booth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);
            return $"Added booth number {booth.BoothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (!allAvailableTypes.Contains(cocktailTypeName))
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if (!coctailSizes.Contains(size))
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            if (booths.Models.FirstOrDefault(b => b.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size) != null) != null)
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            switch (cocktailTypeName)
            {
                case "Hibernation": booth.CocktailMenu.AddModel(new Hibernation(cocktailName, size)); break;
                case "MulledWine": booth.CocktailMenu.AddModel(new MulledWine(cocktailName, size)); break;
            }
            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (!allAvailableTypes.Contains(delicacyTypeName))
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            if (booths.Models.FirstOrDefault(b => b.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName) != null) != null)
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            switch (delicacyTypeName)
            {
                case "Gingerbread": booth.DelicacyMenu.AddModel(new Gingerbread(delicacyName)); break;
                case "Stolen": booth.DelicacyMenu.AddModel(new Stolen(delicacyName)); break;
            }
            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.Charge();
            booth.ChangeStatus();
            return $"Bill {booth.Turnover:f2} lv" + Environment.NewLine + $"Booth {boothId} is now available!";

        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }

            booth.ChangeStatus();
            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth;
            double price;

            string[] splittedOrder = order.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = splittedOrder[0];
            string itemName = splittedOrder[1];
            int oredredPieces = int.Parse(splittedOrder[2]);

            string size = string.Empty;
            if (splittedOrder.Length == 4)
            {
                size = splittedOrder[3];
            }

            if (!allAvailableTypes.Contains(itemTypeName) && !allAvailableTypes.Contains(itemTypeName))
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if (booths.Models.Any(b => b.CocktailMenu.Models.All(c => c.Name != itemName) && b.DelicacyMenu.Models.All(d => d.Name != itemName)))
            {
                switch (itemTypeName)
                {
                    case "Hibernation":
                    case "MulledWine":
                        return $"There is no {size} {itemName} available!";
                    default: //Delicacies Types
                        return $"There is no {itemTypeName} {itemName} available!";
                }
            }

            if (splittedOrder.Length == 4)
            {
                if (booths.Models.Any(b => b.CocktailMenu.Models.All(c => c.Name != itemName && c.Size != size)))
                {
                    return $"There is no {size} {itemName} available!";
                }

                booth = booths.Models.FirstOrDefault(b => b.CocktailMenu.Models.Any(c => c.Name == itemName && c.Size == size));
                price = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size).Price;
                booth.UpdateCurrentBill(price * oredredPieces);
                return $"Booth {boothId} ordered {oredredPieces} {itemName}!";
            }

            if (booths.Models.Any(b => b.DelicacyMenu.Models.All(d => d.Name != itemName)))
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            booth = booths.Models.FirstOrDefault(b => b.DelicacyMenu.Models.Any(d => d.Name == itemName));
            price = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName).Price;
            booth.UpdateCurrentBill(price * oredredPieces);
            return $"Booth {boothId} ordered {oredredPieces} {itemName}!";
        }
    }
}
