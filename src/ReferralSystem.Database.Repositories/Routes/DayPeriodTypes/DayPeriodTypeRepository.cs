using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes.DayPeriodTypes
{
    public class DayPeriodTypeRepository : Repository<DayPeriodType>, IDayPeriodTypeRepository
    {
        public DayPeriodTypeRepository(IDatabaseConnectionFactory connection)
            : base(nameof(DayPeriodType), connection)
        {
        }
    }
}