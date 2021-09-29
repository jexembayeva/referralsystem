using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class LadStop : BaseModel
    {
        protected LadStop()
        {
        }

        public LadStop(
            int stopOrder,
            int distance,
            bool isControlPoint,
            bool isEnding,
            int passCount,
            bool hasLunch,
            long ladId,
            int direction,
            long stopId)
        {
            StopOrder = stopOrder;
            Distance = distance;
            IsControlPoint = isControlPoint;
            IsEnding = isEnding;
            PassCount = passCount;
            HasLunch = hasLunch;
            LadId = ladId;
            Direction = direction;
            StopId = stopId;
        }

        public int StopOrder { get; protected set; }

        public int Distance { get; protected set; }

        public bool IsControlPoint { get; protected set; }

        public bool IsEnding { get; protected set; }

        public int PassCount { get; protected set; }

        public bool HasLunch { get; protected set; }

        public long LadId { get; protected set; }

        public int Direction { get; protected set; }

        public long StopId { get; protected set; }

        public void UpdateOrFail(
            int stopOrder,
            int distance,
            bool isControlPoint,
            bool isEnding,
            int passCount,
            bool hasLunch,
            long ladId,
            int direction,
            long stopId)
        {
            StopOrder = stopOrder;
            Distance = distance;
            IsControlPoint = isControlPoint;
            IsEnding = isEnding;
            PassCount = passCount;
            HasLunch = hasLunch;
            LadId = ladId;
            Direction = direction;
            StopId = stopId;

            this.ThrowIfInvalid();
        }
    }
}