using Rebar_project.Models;
using MongoDB.Driver;
using static Rebar_project.Models.ShakeOrder;
using Rebar_project.models;

namespace Rebar_project.DataAccess
{
    public class OrderDataAccess :DataAccess
    {
        private const string OrdersCollection = "Orders";
        public async Task<List<OrderDB>> GetOrders()
        {
            var ordersCollection = ConnectToMongo<OrderDB>(OrdersCollection);
            var result = await ordersCollection.FindAsync(_ => true);
            return result.ToList();
        }
        public async Task AddOrder(List<ShakeOrder> ShakeOrder, Discount discounts, string name)
        {
            if (ShakeOrder.Count <= 10 || !string.IsNullOrWhiteSpace(name))
            {
                var orderManager = new OrderService();
                var shakesCollection = ConnectToMongo<ShakeMenu>("Shakes");
                var shakeOrderList = new List<ShakeOrder>();
                foreach (var shakeOrder in ShakeOrder)
                {
                    var filter = Builders<ShakeMenu>.Filter.Eq(x => x.NameOfShake, shakeOrder.ShakeName);
                    var existingShake = await shakesCollection.Find(filter).FirstOrDefaultAsync();

                    if (existingShake != null)
                    {
                        orderManager.InitData(shakeOrder, existingShake);
                        shakeOrderList.Add(shakeOrder);
                    }
                    else
                    {
                        Console.WriteLine("No matching Shake found for the ShakeOrder.");

                    }
                }
                double totalPrice = ShakeOrder.Sum(shakes => shakes.Price);
                List<Guid> shakeIDs = ShakeOrder.ConvertAll(shakes => shakes.ShakeID);

                Order order= new Order(shakeOrderList, name, totalPrice, discounts.Percentage);
                var orderCollection = ConnectToMongo<OrderDB>(OrdersCollection);
                await orderCollection.InsertOneAsync(new OrderDB(order.OrderDate, shakeIDs, totalPrice, name));
            }
        }
    }
}
