using System.Threading;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Dtos.Devices
{
    public class DeviceDto : BaseModelDto
    {
        public long FirmWareId { get; set; }

        public long StabilizerId { get; set; }

        public long SimcardId { get; set; }

        public int IMEI { get; set; }

        public string SerialNumber { get; set; }

        public string Comment { get; set; }

        public Device NewDevice()
        {
            return new Device(
                imei: IMEI,
                serialNumber: SerialNumber,
                comment: Comment);
        }
    }
}