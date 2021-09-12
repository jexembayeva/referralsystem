using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Lad : BaseModel
    {
        public int Direction { get; set; }

        public int Length { get; set; }

        public int Stops { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int TransitTime { get; set; }

        public long AlternativeId { get; set; }
    }
}