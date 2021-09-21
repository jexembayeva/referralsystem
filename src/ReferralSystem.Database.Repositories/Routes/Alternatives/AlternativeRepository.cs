using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes.Alternatives
{
    public class AlternativeRepository : Repository<Alternative>, IAlternativeRepository
    {
        public AlternativeRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Alternative), connection)
        {
        }
    }
}