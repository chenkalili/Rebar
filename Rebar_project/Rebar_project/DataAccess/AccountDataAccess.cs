using Rebar_project.Models;
using MongoDB.Driver;

namespace Rebar_project.DataAccess
{
    public class AccountDataAccess :DataAccess
    {
        private const string AccountsCollection = "Accounts";
        public async Task<List<Account>> GetAccounts()
        {
            var accountCollection = ConnectToMongo<Account>(AccountsCollection);
            var result = await accountCollection.FindAsync(_ => true);
            return result.ToList();
        }
        public Task AddAccount(Account account)
        {
            var accountCollection = ConnectToMongo<Account>(AccountsCollection);
            return accountCollection.InsertOneAsync(account);
        }
    }
}
