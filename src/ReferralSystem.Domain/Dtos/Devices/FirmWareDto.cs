using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Dtos.Devices
{
    public class FirmWareDto : BaseModelDto
    {
        public string Name { get; set; }

        public string Config { get; set; }

        public string Comment { get; set; }

        public FirmWare NewFirmWare()
        {
            return new FirmWare(
                name: Name,
                comment: Comment,
                config: Config);
        }
    }
}
