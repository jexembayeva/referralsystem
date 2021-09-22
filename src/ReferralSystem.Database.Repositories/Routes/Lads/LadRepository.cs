using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes.Lads
{
    public class LadRepository : Repository<Lad>, ILadRepository
    {
        public LadRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Lad), connection)
        {
        }
    }
}