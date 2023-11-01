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
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public List<ShakeOrder> ShakeOrders { get; set; } = new List<ShakeOrder>();
        public double TotalPriceOfShakes { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Discount> Discounts { get; set; } = new List<Discount>();

        public Order(List<ShakeOrder> shakesList,string customerName,double totalPrice, double totalDiscount)
        {
            OrderID = Guid.NewGuid();
            CustomerName = customerName;
            ShakeOrders = shakesList;
            TotalPriceOfShakes = totalPrice;
            OrderDate = DateTime.Now;
            double discount = totalDiscount;
            TotalPriceOfShakes = TotalPriceOfShakes / discount;
        }
    }
}
