using Microsoft.AspNetCore.Components.Forms;
using Rebar_project.DataAccess;

namespace Rebar_project.Models
{
    public class OrderService
    {
        Order Order;


        public OrderService(List<ShakeOrder> shakesList)
        { 

        }
        public bool NewOrder(List<ShakeOrder> shakesList, List<Discount> discounts, string name)
        {
            if (shakesList.Count > 9 || name == null)
                return false;
            Order = new Order(shakesList,name, discounts);
            //OrderDataAccess orderData = new OrderDataAccess(_order);
            return true;
        }
    }
}
