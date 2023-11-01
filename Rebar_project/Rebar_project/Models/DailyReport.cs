using MongoDB.Bson.Serialization.Attributes;

namespace Rebar_project.Models
{
    public class DailyReport
    {
        [BsonId]
        public Guid ID { get; set; }
        public Guid ReportID { get; set; }
        public DateTime TodayDate { get; set; } = DateTime.Today;
        public double SumPrice { get; set; } = 0;
        public int SumOrders { get; set; } = 0;

        public string ManagerPassword = "1234";
        public DailyReport() 
        {
            ReportID = Guid.NewGuid();
        }
    }
}
