namespace Rebar_project.Models
{
    public class Account
    {
        public List<OrderDB> OrderList { get; set; } = new List<OrderDB>();
        public double TotalAmount { get; set; } = 0;
        public Account() { }

        public void OrdersTotalPrice()
        {
            TotalAmount = OrderList.Sum(order => order.TotalPrice);
        }
    }
}
