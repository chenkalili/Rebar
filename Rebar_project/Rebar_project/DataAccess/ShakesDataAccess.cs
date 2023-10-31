
using MongoDB.Driver;
using Rebar_project.models;

namespace Rebar_project.DataAccess
{
    public class ShakesDataAccess : DataAccess
    {
        private const string ShakeCollection = "Shakes";
        public async Task<List<Shakes>> GetShakes()
        {
            var menuCollection = ConnectToMongo<Shakes>(ShakeCollection);
            var result = await menuCollection.FindAsync(_ => true);
            return result.ToList();
        }
        public Task AddShake(Shakes menuShake)
        {
            var menuShakeCollection = ConnectToMongo<Shakes>(ShakeCollection);
            return menuShakeCollection.InsertOneAsync(menuShake);
        }
    }
}
