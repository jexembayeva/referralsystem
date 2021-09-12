using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class LadStop : BaseModel
    {
        public int StopOrder { get; set; }

        public int Distance { get; set; }

        public bool IsControlPoint { get; set; }

        public bool IsEnding { get; set; }

        public int PassCount { get; set; }

        public bool HasLunch { get; set; }

        public bool AlternativeId { get; set; }

        public bool LadId { get; set; }

        public int Direction { get; set; }

        public long StopId { get; set; }
    }
}