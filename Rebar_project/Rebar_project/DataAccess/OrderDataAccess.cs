using Rebar_project.Models;
using MongoDB.Driver;

namespace Rebar_project.DataAccess
{
    public class OrderDataAccess :DataAccess
    {
        private const string OrdersCollection = "Orders";
        public async Task<List<Order>> GetOrders()
        {
            var ordersCollection = ConnectToMongo<Order>(OrdersCollection);
            var result = await ordersCollection.FindAsync(_ => true);
            return result.ToList();
        }
        public Task AddOrder(Order order)
        {
            var orderCollection = ConnectToMongo<Order>(OrdersCollection);
            return orderCollection.InsertOneAsync(order);
        }
    }
}
