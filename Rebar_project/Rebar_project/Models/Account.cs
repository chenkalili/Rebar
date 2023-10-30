namespace Rebar_project.Models
{
    public class Account
    {
        public List<Order> _orderList { get; set; } = new List<Order>();
        public double _totalAmount { get; set; } = 0;

        public Account(List<Order> orderList, double totalAmount) 
        {
            _orderList = orderList;
            _totalAmount = totalAmount;
        }    
    }
}
