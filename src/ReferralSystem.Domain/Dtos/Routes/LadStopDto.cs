using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class LadStopDto : BaseModelDto
    {
        public int StopOrder { get; set; }

        public int Distance { get; set; }

        public bool IsControlPoint { get; set; }

        public bool IsEnding { get; set; }

        public int PassCount { get; set; }

        public bool HasLunch { get; set; }

        public long LadId { get; set; }

        public int Direction { get; set; }

        public long StopId { get; set; }

        public LadStop NewLadStop()
        {
            return new LadStop(
                stopOrder: StopOrder,
                distance: Distance,
                isControlPoint: IsControlPoint,
                isEnding: IsEnding,
                passCount: PassCount,
                hasLunch: HasLunch,
                ladId: LadId,
                direction: Direction,
                stopId: StopId);
        }
    }
}
