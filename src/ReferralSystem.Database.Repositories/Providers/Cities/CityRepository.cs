using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Providers;
using Utils.Helpers;

namespace ReferralSystem.Database.Repositories.Providers.Cities
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDatabaseConnectionFactory connection)
            : base(nameof(City), connection)
        {
            connection.ThrowIfNull(nameof(connection));
        }
    }
}
