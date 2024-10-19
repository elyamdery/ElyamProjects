using SQLite;
using Bingie.Models;
using Microsoft.Extensions.Logging;

namespace Bingie.Services
{
    public interface IDataStore
    {
        Task<User> GetUserAsync(string username);
        Task<bool> AddUserAsync(User user);
        Task<bool> AddBingeEntryAsync(BingeEntry entry);
        Task<List<BingeEntry>> GetBingeEntriesForDateAsync(DateTime date);
    }

    public class DataStore : IDataStore
    {
        private readonly SQLiteAsyncConnection _database;
        private readonly ILogger<DataStore> _logger;

        public DataStore(ILogger<DataStore> logger)
        {
            _logger = logger;
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "bingie.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<BingeEntry>().Wait();
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _database.Table<User>().Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await _database.InsertAsync(user);
            return true;
        }

        public async Task<bool> AddBingeEntryAsync(BingeEntry entry)
        {
            await _database.InsertAsync(entry);
            return true;
        }

        public async Task<List<BingeEntry>> GetBingeEntriesForDateAsync(DateTime date)
        {
            return await _database.Table<BingeEntry>()
                .Where(e => e.Date.Date == date.Date)
                .ToListAsync();
        }
    }
}