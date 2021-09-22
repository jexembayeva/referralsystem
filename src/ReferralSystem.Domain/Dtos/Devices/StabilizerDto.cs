using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Dtos.Devices
{
    public class StabilizerDto : BaseModelDto
    {
        public string Name { get; set; }

        public string Comment { get; set; }

        public Stabilizer NewStabilizer()
        {
            return new Stabilizer(
                name: Name,
                comment: Comment);
        }
    }
}
