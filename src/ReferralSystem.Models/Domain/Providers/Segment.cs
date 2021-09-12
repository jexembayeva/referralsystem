using System;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Segment : BaseModel
    {
        public int Length { get; set; }

        public int LineCount { get; set; }

        public bool ParkingAllowed { get; set; }

        public int MaxSpeed { get; set; }

        public bool OneWay { get; set; }

        public int Direction { get; set; }

        public bool RailCrossing { get; set; }

        public long DedicatedLaneId { get; set; }

        public int DirectDirectionLaneCount { get; set; }

        public int ReverseDirectionLaneCount { get; set; }

        public int DirectDirectionDedicatedLaneCount { get; set; }

        public int ReverseDirectionDedicatedLaneCount { get; set; }

        public bool HasPublicTransport { get; set; }

        public string TurnRestrictions { get; set; }

        public double Geometry { get; set; }

        public string Comment { get; set; }

        public long DistrictId { get; set; }

        public long StreetId { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset ValidTo { get; set; }
    }
}