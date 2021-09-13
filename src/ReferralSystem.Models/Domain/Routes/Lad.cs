using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Lad : BaseModel
    {
        protected Lad()
        {
        }

        public int Direction { get; protected set; }

        public int Length { get; protected set; }

        public int Stops { get; protected set; }

        public string Name { get; protected set; }

        public string Comment { get; protected set; }

        public int TransitTime { get; protected set; }

        public long AlternativeId { get; protected set; }
    }
}