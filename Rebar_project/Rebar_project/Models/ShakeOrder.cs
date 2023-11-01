using MongoDB.Bson.Serialization.Attributes;
using Rebar_project.models;

namespace Rebar_project.Models
{
    public class ShakeOrder
    {
        [BsonId]
        public Guid ID { get;}
        public Guid ShakeID { get; set; }
        public string ShakeName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public ChooseSize Size { get; set; }

        public ShakeOrder(string shakeName,ChooseSize size)
        {
            ShakeID = Guid.NewGuid();
            ShakeName = shakeName;
            Size = size;
        }
        public enum ChooseSize
        {
            L,
            M,
            S,
        }
    }
}
