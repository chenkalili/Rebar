using Rebar_project.models;
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Rebar_project.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        public string OrderID { get; set; }
        public List<ShakeOrder> ShakeOrders { get; set; } = new List<ShakeOrder>();
        public double TotalPriceOfShakes { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Discount> Discounts { get; set; } = new List<Discount>();
        public Order(string customerName,double totalPriceOfShakes)
        {
            OrderID = Guid.NewGuid().ToString();
            CustomerName = customerName;
            TotalPriceOfShakes = totalPriceOfShakes;
        }

        public Order(List<ShakeOrder> shakesList,string customerName, List<Discount> discounts)
        {
            OrderID = Guid.NewGuid().ToString();
            CustomerName = customerName;
            ShakeOrders = shakesList;
            TotalPriceOfShakes = TotalPrice(shakesList);
            OrderDate = DateTime.Now;
            double discount = TotalDiscount(discounts);
            TotalPriceOfShakes = TotalPriceOfShakes / discount;
        }
        public double TotalPrice(List<ShakeOrder> shakesList)
        {
            double totalPrice = 0;
            shakesList.ForEach(shakes => { totalPrice += shakes.Price; });
            return totalPrice;
        }
        public double TotalDiscount(List<Discount> discounts)
        {
            double totalDiscounts = 0;
            discounts.ForEach(discount => { totalDiscounts += discount.Percentage; });
            return totalDiscounts;
        }
    }
}
