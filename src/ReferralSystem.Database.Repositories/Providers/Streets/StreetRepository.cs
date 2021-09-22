using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Providers;
using Utils.Helpers;

namespace ReferralSystem.Database.Repositories.Providers.Streets
{
    public class StreetRepository : Repository<Street>, IStreetRepository
    {
        public StreetRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Street), connection)
        {
            connection.ThrowIfNull(nameof(connection));
        }
    }
}
