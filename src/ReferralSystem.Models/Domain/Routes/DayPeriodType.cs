using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class DayPeriodType : BaseModel
    {
        protected DayPeriodType()
        {
        }

        public string Name { get; protected set; }

        public int Direction { get; protected set; }

        public long AlternativeId { get; protected set; }
    }
}