using System;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class DedicatedLaneDto : BaseModelDto
    {
        public string Name { get; set; }

        public int PeakSpeed { get; set; }

        public int OffPeakSpeed { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

        public DedicatedLane NewDedicatedLane()
        {
            return new DedicatedLane(
                name: Name,
                peakSpeed: PeakSpeed,
                offPeakSpeed: OffPeakSpeed,
                validFrom: ValidFrom,
                validTo: ValidTo);
        }
    }
}
