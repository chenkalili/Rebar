
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

        public async Task<ShakeMenu> GetShakeById(string id)
        {
            if (Guid.TryParse(id, out Guid shakeId))
            {
                var menuCollection = ConnectToMongo<ShakeMenu>(ShakeCollection);
                var filter = Builders<ShakeMenu>.Filter.Eq(x => x.ShakeID, shakeId);
                return await menuCollection.Find(filter).FirstOrDefaultAsync();
            }
            else
            {
                throw new ArgumentException("Invalid Shake ID format.");
            }
        }


        public async Task UpdateShake(ShakeMenu updatedShake)
        {
            var menuCollection = ConnectToMongo<ShakeMenu>(ShakeCollection);
            var filter = Builders<ShakeMenu>.Filter.Eq(x => x.ShakeID, updatedShake.ShakeID);
            var update = Builders<ShakeMenu>.Update
                .Set(x => x.NameOfShake, updatedShake.NameOfShake)
                .Set(x => x.Description, updatedShake.Description)
                .Set(x => x.PriceLarge, updatedShake.PriceLarge)
                .Set(x => x.PriceMedium, updatedShake.PriceMedium)
                .Set(x => x.PriceSmall, updatedShake.PriceSmall);
            await menuCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteShake(string id)
        {
            var menuCollection = ConnectToMongo<ShakeMenu>(ShakeCollection);
            var filter = Builders<ShakeMenu>.Filter.Eq(x => x.ShakeID.ToString(), id);
            await menuCollection.DeleteOneAsync(filter);
        }
    }
}
