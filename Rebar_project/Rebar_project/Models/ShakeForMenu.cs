using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Rebar_project.models
{
    class Shake
    {

       // [BsonId]
        public Guid _shakeID { get; }
      //  [BsonElement("name")]
        public string _name { get; set; }
      //  [BsonElement("description")]
        public string _description { get; set; }

       // [BsonElement("priceLarge")]
        public double _priceLarge { get; set; }
       // [BsonElement("priceMedium")]
        public double _priceMedium { get; set; }
       // [BsonElement("priceSmall")]
        public double _priceSmall { get; set; }

    public Shake(string name, string description, double priceLarge, double priceMedium, double priceSmall)
        {
            _shakeID = Guid.NewGuid();
            _name = name;
            _description = description;
            _priceLarge = priceLarge;
            _priceMedium = priceMedium;
            _priceSmall = priceSmall;
        }
    }
}
