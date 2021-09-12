using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Bases;

namespace ReferralSystem.Database.Repositories.Bases
{
    public class BaseRepository : Repository<BasePlatform>, IBaseRepository
    {
        public BaseRepository(IDatabaseConnectionFactory connection)
            : base(nameof(BasePlatform), connection)
        {
        }
    }
}