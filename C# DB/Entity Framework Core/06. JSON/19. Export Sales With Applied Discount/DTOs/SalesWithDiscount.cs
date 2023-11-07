using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CarDealer.Models;
using Newtonsoft.Json;

namespace _19._Export_Sales_With_Applied_Discount.DTOs
{
    public class SalesWithDiscount
    {
        private decimal discount;
        private decimal price;
        private decimal priceWithDiscount;

        public SalesWithDiscount(Car car, string customerName, decimal discount)
        {
            this.Car = car;
            this.CustomerName = customerName;

            this.discount = discount;
            this.price = car.PartsCars.Sum(pc => pc.Part.Price);
            this.priceWithDiscount = this.price * (1 - this.discount / 100);
        }

        [JsonProperty("car")]
        public Car Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("discount")] 
        public string Discount => $"{this.discount:f2}";

        [JsonProperty("price")] 
        public string Price => $"{this.price:f2}";

        [JsonProperty("priceWithDiscount")] public string PriceWithDiscount => $"{this.priceWithDiscount:f2}";

    }
}
