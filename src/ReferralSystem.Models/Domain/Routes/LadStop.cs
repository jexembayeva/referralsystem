using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class LadStop : BaseModel
    {
        protected LadStop()
        {
        }

        public int StopOrder { get; protected set; }

        public int Distance { get; protected set; }

        public bool IsControlPoint { get; protected set; }

        public bool IsEnding { get; protected set; }

        public int PassCount { get; protected set; }

        public bool HasLunch { get; protected set; }

        public bool AlternativeId { get; protected set; }

        public bool LadId { get; protected set; }

        public int Direction { get; protected set; }

        public long StopId { get; protected set; }
    }
}