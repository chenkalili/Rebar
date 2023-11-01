
using MongoDB.Driver;
using Rebar_project.models;
using Rebar_project.Models;

namespace Rebar_project.DataAccess
{
    public class DailyReportDataAccess :DataAccess
    {

        private const string DailyReportCollection = "DailyReport";

        DailyReport dailyReport= new DailyReport();

        Account Account = new Account();
        public async Task AddDailyReport(string password)
        {
            if (password == dailyReport.ManagerPassword)
            {
                var ordersCollection = ConnectToMongo<OrderDB>("OrderDB");
                var filter = Builders<OrderDB>.Filter.Eq(x => x.OrderCreateTime, dailyReport.TodayDate);
                var orderList = await ordersCollection.Find(filter).ToListAsync();
                Account.OrderList.AddRange(orderList);
                Account.OrdersTotalPrice();
                dailyReport.SumOrders = orderList.Count();
                dailyReport.SumPrice = Account.TotalAmount;
                var dailyReportCollection = ConnectToMongo<DailyReport>("DailyReport");
                await dailyReportCollection.InsertOneAsync(dailyReport);
            }
        }
        public async Task<List<DailyReport>> GetDailyReport()
        {
            var menuCollection = ConnectToMongo<DailyReport>(DailyReportCollection);
            var result = await menuCollection.FindAsync(_ => true);
            return result.ToList();
        }
    }
}
