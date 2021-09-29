using System;
using ReferralSystem.Models.Domain.Devices;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos.Devices
{
    public class DeviceDto : BaseModelDto, IHasFromToDates
    {
        public long FirmWareId { get; set; }

        public long StabilizerId { get; set; }

        public long SimcardId { get; set; }

        public int IMEI { get; set; }

        public string SerialNumber { get; set; }

        public string Comment { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

        public Device NewDevice()
        {
            return new Device(
                firmWareId: FirmWareId,
                stabilizerId: StabilizerId,
                simcardId: SimcardId,
                imei: IMEI,
                serialNumber: SerialNumber,
                comment: Comment,
                validFrom: ValidFrom,
                validTo: ValidTo);
        }
    }
}