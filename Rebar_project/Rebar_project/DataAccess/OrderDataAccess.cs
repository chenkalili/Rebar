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
            if (ShakeOrder.Count <= 10 && !string.IsNullOrWhiteSpace(name))
            {
                var shakesCollection = ConnectToMongo<ShakeMenu>("Shakes");
                var shakeOrderList = new List<ShakeOrder>();

                var existingShakes = await GetExisMenuShakes(shakeOrderList);
                var shakeOrderListWithDetails = InitShakeOrderList(shakeOrderList, existingShakes);
                
                double totalPrice = ShakeOrder.Sum(shakes => shakes.Price);
                List<Guid> shakeIDs = shakeOrderList.Select(shake => shake.ShakeID).ToList();

                Order order = new Order(shakeOrderList, name, totalPrice, discounts.Percentage);
                var orderCollection = ConnectToMongo<OrderDB>(OrdersCollection);
                await orderCollection.InsertOneAsync(new OrderDB(order.OrderDate, shakeIDs, totalPrice, name));
            }
        }

        private async Task<List<ShakeMenu>> GetExisMenuShakes(List<ShakeOrder> shakeOrderList)
        {
            var shakesCollection = ConnectToMongo<ShakeMenu>("Shakes");
            var shakeNames = shakeOrderList.Select(shakeOrder => shakeOrder.ShakeName).ToList();
            var filter = Builders<ShakeMenu>.Filter.In(x => x.NameOfShake, shakeNames);
            return await shakesCollection.Find(filter).ToListAsync();
        }

        private List<ShakeOrder> InitShakeOrderList(List<ShakeOrder> shakeOrderList, List<ShakeMenu> existingShakes)
        {
            var shakeOrderListWithDetails = new List<ShakeOrder>();
            foreach (var shakeOrder in shakeOrderList)
            {
                var existingShake = existingShakes.FirstOrDefault(shake => shake.NameOfShake == shakeOrder.ShakeName);
                try
                    {
                        InitData(shakeOrder, existingShake);
                        shakeOrderListWithDetails.Add(shakeOrder);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error initializing ShakeOrder: {ex.Message}");
                    }
            }
            return shakeOrderListWithDetails;
        }
        public async Task<OrderDB> GetOrderById(string id)
        {
            if (Guid.TryParse(id, out Guid orderId))
            {
                var ordersCollection = ConnectToMongo<OrderDB>(OrdersCollection);
                var filter = Builders<OrderDB>.Filter.Eq(x => x.OrderID, orderId);
                return await ordersCollection.Find(filter).FirstOrDefaultAsync();
            }
            else
            {
                throw new ArgumentException("Invalid Order ID format.");
            }
        }


        public async Task UpdateOrder(OrderDB updatedOrder)
        {
            var ordersCollection = ConnectToMongo<OrderDB>(OrdersCollection);
            var filter = Builders<OrderDB>.Filter.Eq(x => x.OrderID, updatedOrder.OrderID);
            var update = Builders<OrderDB>.Update
                .Set(x => x.OrderCreateTime, updatedOrder.OrderCreateTime)
                .Set(x => x.ReadyOrderTime, updatedOrder.ReadyOrderTime)
                .Set(x => x.OrderID, updatedOrder.OrderID)
                .Set(x => x.TotalPrice, updatedOrder.TotalPrice)
                .Set(x => x.CustomerName, updatedOrder.CustomerName);
            await ordersCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteOrder(string id)
        {
            if (Guid.TryParse(id, out Guid orderId))
            {
                var ordersCollection = ConnectToMongo<OrderDB>(OrdersCollection);
                var filter = Builders<OrderDB>.Filter.Eq(x => x.OrderID, orderId);
                await ordersCollection.DeleteOneAsync(filter);
            }
            else
            {
                throw new ArgumentException("Invalid Order ID format.");
            }
        }


        public void InitData(ShakeOrder shakeOrder, ShakeMenu shakeMenu)
        {
            switch (shakeOrder.Size)
            {
                case ChooseSize.S:
                    shakeOrder.Price = shakeMenu.PriceSmall;
                    break;
                case ChooseSize.M:
                    shakeOrder.Price = shakeMenu.PriceMedium;
                    break;
                case ChooseSize.L:
                    shakeOrder.Price = shakeMenu.PriceLarge;
                    break;
                default:
                    break;
            }
            shakeOrder.Description = shakeMenu.Description;
        }
    }
}
