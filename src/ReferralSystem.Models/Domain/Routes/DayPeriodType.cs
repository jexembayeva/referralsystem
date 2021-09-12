using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class DayPeriodType : BaseModel
    {
        public string Name { get; set; }

        public int Direction { get; set; }

        public long AlternativeId { get; set; }
    }
}