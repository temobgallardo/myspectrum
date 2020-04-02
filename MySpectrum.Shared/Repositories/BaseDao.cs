using MySpectrum.Models.Users;
using SQLite;
using System.Threading.Tasks;

namespace MySpectrum.Shared.Repositories
{
    public class BaseDao
    {
        private SQLiteAsyncConnection db = null;
        private readonly IDatabasePath _databasePath;
        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database accesss
        SQLite.SQLiteOpenFlags.SharedCache;

        public BaseDao(IDatabasePath databasePath) 
        {
            _databasePath = databasePath;
        }

        protected async Task<SQLiteAsyncConnection> GetInstance() 
        {
            if (db == null) 
            {
                db = new SQLiteAsyncConnection(_databasePath.GetPath(), Flags);
                await db.CreateTableAsync<User>();
            }

            return db;
        }
    }
}
