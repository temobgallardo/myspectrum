using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySpectrum.Shared.Repositories
{
    public interface IDao<T>
    {
        Task<List<T>> GetEntitiesAsync();
        Task<int> SaveEntityAsync(T entity);
        Task<int> DeleteAllEntitiesAsync();
    }
}
