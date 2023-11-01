
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
        public async Task<DailyReport> GetDailyReportById(string id)
        {
            if (Guid.TryParse(id, out Guid reportId))
            {
                var dailyReportCollection = ConnectToMongo<DailyReport>(DailyReportCollection);
                var filter = Builders<DailyReport>.Filter.Eq(x => x.ReportID, reportId);
                return await dailyReportCollection.Find(filter).FirstOrDefaultAsync();
            }
            else
            {
                throw new ArgumentException("Invalid report ID format.");
            }
        }


        public async Task UpdateDailyReport(DailyReport updatedReport)
        {
            var dailyReportCollection = ConnectToMongo<DailyReport>(DailyReportCollection);
            var filter = Builders<DailyReport>.Filter.Eq(x => x.ReportID, updatedReport.ReportID);
            var update = Builders<DailyReport>.Update
                .Set(x => x.SumOrders, updatedReport.SumOrders)
                .Set(x => x.SumPrice, updatedReport.SumPrice);
            await dailyReportCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteDailyReport(string id)
        {
            if (Guid.TryParse(id, out Guid reportId))
            {
                var dailyReportCollection = ConnectToMongo<DailyReport>(DailyReportCollection);
                var filter = Builders<DailyReport>.Filter.Eq(x => x.ReportID, reportId);
                await dailyReportCollection.DeleteOneAsync(filter);
            }
            else
            {
                throw new ArgumentException("Invalid report ID format.");
            }
        }
    }
}
