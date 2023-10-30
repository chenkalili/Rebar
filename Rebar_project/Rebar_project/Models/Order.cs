using Rebar_project.models;

namespace Rebar_project.Models
{
    public class Order
    {
        public Guid _orderID { get; set; }
        public List<ShakeForOrder> _shakeForOrders { get; set; } = new List<ShakeForOrder>();
        public double _totalPriceOfShakes { get; set; }
        public string _customerName { get; set; }
        public DateTime _orderDate { get; set; }
        public List<Discount> _discounts { get; set; } = new List<Discount>();
    }
}
