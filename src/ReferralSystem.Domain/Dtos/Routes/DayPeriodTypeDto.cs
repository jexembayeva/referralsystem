using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class DayPeriodTypeDto : BaseModelDto
    {
        public string Name { get; set; }

        public int Direction { get; set; }

        public long AlternativeId { get; set; }

        public DayPeriodType NewDayPeriodType()
        {
            return new DayPeriodType(
                name: Name,
                direction: Direction,
                alternativeId: AlternativeId);
        }
    }
}
