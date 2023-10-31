namespace Rebar_project.Models
{
    public class Account
    {
        public List<Order> OrderList { get; set; } = new List<Order>();
        public double TotalAmount { get; set; } = 0;

        public Account(List<Order> orderList, double totalAmount) 
        {
            OrderList = orderList;
            TotalAmount = totalAmount;
        }    
    }
}
