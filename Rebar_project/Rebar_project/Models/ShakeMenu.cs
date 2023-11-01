using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Rebar_project.models
{
    public class ShakeMenu
    {
        [BsonId]
        public Guid ID { get; set; }
        public Guid ShakeID { get; set; }
        public string NameOfShake { get; set; }
        public string Description { get; set; }
        public double PriceLarge { get; set; }
        public double PriceMedium { get; set; }
        public double PriceSmall { get; set; }

        public ShakeMenu(string nameOfShake, string description, double priceLarge, double priceMedium, double priceSmall)
        {
            ShakeID = Guid.NewGuid();
            NameOfShake = nameOfShake;
            Description = description;
            PriceLarge = priceLarge;
            PriceMedium = priceMedium;
            PriceSmall = priceSmall;
        }
    }
}
