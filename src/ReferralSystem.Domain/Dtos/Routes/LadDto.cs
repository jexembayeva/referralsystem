using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class LadDto : BaseModelDto
    {
        public int Direction { get; set; }

        public int Length { get; set; }

        public int Stops { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int TransitTime { get; set; }

        public long AlternativeId { get; set; }

        public Lad NewLad()
        {
            return new Lad(
                name: Name,
                direction: Direction,
                comment: Comment);
        }
    }
}
