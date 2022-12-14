using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace ReferralSystem.Database.Repositories.Base
{
    public interface IRepository<TEntity>
        where TEntity : class, IBaseModel
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<TEntity> GetByIdAsync(long id);

        Task UpdateAsync(TEntity data);

        Task InsertAsync(TEntity entity);

        Task InsertAsync(TEntity entityToInsert, TEntity entityToMakeOutdated);
    }
}