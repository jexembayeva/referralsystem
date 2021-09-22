using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class DayPeriodType : BaseModel
    {
        protected DayPeriodType()
        {
        }

        public DayPeriodType(string name, int direction, long alternativeId)
        {
            Name = name;
            Direction = direction;
            AlternativeId = alternativeId;
        }

        public string Name { get; protected set; }

        public int Direction { get; protected set; }

        public long AlternativeId { get; protected set; }

        public void UpdateOrFail(string name, int direction, long alternativeId)
        {
            Name = name;
            Direction = direction;
            AlternativeId = alternativeId;

            this.ThrowIfInvalid();
        }
    }
}