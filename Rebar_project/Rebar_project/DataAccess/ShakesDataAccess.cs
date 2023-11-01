
using MongoDB.Driver;
using Rebar_project.models;

namespace Rebar_project.DataAccess
{
    public class ShakesDataAccess : DataAccess
    {
        private const string ShakeCollection = "Shakes";
        public async Task<List<ShakeMenu>> GetShakes()
        {
            var menuCollection = ConnectToMongo<ShakeMenu>(ShakeCollection);
            var result = await menuCollection.FindAsync(_ => true);
            return result.ToList();
        }
        public Task AddShake(ShakeMenu menuShake)
        {
            var menuShakeCollection = ConnectToMongo<ShakeMenu>(ShakeCollection);
            return menuShakeCollection.InsertOneAsync(menuShake);
        }
    }
}
