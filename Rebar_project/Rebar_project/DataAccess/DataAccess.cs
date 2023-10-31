using MongoDB.Driver;

namespace Rebar_project.DataAccess
{
    public class DataAccess
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DataBaseName = "Rebar";
        protected IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DataBaseName);
            return db.GetCollection<T>(collection);
        }
    }
}
