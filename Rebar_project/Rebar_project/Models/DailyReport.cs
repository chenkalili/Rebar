namespace Rebar_project.Models
{
    public class DailyReport
    {
        public DateTime TodayDate { get; set; } = DateTime.Today;
        public double SumPrice { get; set; } = 0;
        public int SumOrders { get; set; } = 0;

        public string ManagerPassword = "1234";
        public DailyReport() 
        {

        }
    }
}
