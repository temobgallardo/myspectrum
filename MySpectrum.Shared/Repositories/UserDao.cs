using MySpectrum.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySpectrum.Shared.Repositories
{
    public class UserDao : BaseDao, IDao<User>
    {
        public UserDao(IDatabasePath databasePath) : base(databasePath)
        {
        }

        public async Task<List<User>> GetEntitiesAsync()
        {
            var db = await GetInstance();
            return await db.Table<User>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveEntityAsync(User entity)
        {
            var db = await GetInstance();
            if (entity.Id != 0)
            {
                return await db.UpdateAsync(entity).ConfigureAwait(false);
            }
            else
            {
                return await db.InsertAsync(entity).ConfigureAwait(false); ;
            }
        }

        public async Task<int> DeleteAllEntitiesAsync()
        {
            var db = await GetInstance();
            return await db.DeleteAllAsync<User>().ConfigureAwait(false); ;
        }
    }
}
