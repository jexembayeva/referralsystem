using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Database.Repositories.Providers
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Provider), connection)
        {
        }
    }
}