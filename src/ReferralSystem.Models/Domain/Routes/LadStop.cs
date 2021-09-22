using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class LadStop : BaseModel
    {
        protected LadStop()
        {
        }

        public LadStop(int stopOrder, int distance, int passCount)
        {
            StopOrder = stopOrder;
            Distance = distance;
            PassCount = passCount;
        }

        public int StopOrder { get; protected set; }

        public int Distance { get; protected set; }

        public bool IsControlPoint { get; protected set; }

        public bool IsEnding { get; protected set; }

        public int PassCount { get; protected set; }

        public bool HasLunch { get; protected set; }

        public long AlternativeId { get; protected set; }

        public long LadId { get; protected set; }

        public int Direction { get; protected set; }

        public long StopId { get; protected set; }

        public void UpdateOrFail(int stopOrder, int distance, int passCount)
        {
            StopOrder = stopOrder;
            Distance = distance;
            PassCount = passCount;

            this.ThrowIfInvalid();
        }
    }
}