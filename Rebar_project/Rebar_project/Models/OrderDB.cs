using MongoDB.Bson.Serialization.Attributes;

namespace Rebar_project.Models
{
    public class OrderDB
    {
        [BsonId]
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public DateTime OrderCreateTime { get; set; }
        public DateTime ReadyOrderTime { get; set; }
        public List<Guid> ShakesID { get; set; } = new List<Guid>();
        public double TotalPrice { get; set; }
        public string CustomerName { get; set; }

        public OrderDB(DateTime orderCreateTime,List<Guid> shakesID, double totalPrice, string customerName) 
        {
            OrderID = Guid.NewGuid();
            OrderCreateTime = orderCreateTime;
            ReadyOrderTime = DateTime.Now;
            ShakesID = shakesID;
            TotalPrice = totalPrice;
            CustomerName = customerName;
        }
    }
}
