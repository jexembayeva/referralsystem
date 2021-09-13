using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Segments
{
    public class Segment : BaseModel
    {
        protected Segment()
        {
        }

        public Segment(
            int length,
            int lineCount,
            bool parkingAllowed,
            int maxSpeed,
            bool oneWay,
            int direction,
            bool railCrossing,
            int directDirectionLaneCount,
            int reverseDirectionLaneCount,
            int directDirectionDedicatedLaneCount,
            int reverseDirectionDedicatedLaneCount,
            bool hasPublicTransport,
            string turnRestrictions,
            double geometry,
            string comment,
            long districtId,
            long streetId,
            string token)
        {
            Length = length;
            LineCount = lineCount;
            ParkingAllowed = parkingAllowed;
            MaxSpeed = maxSpeed;
            OneWay = oneWay;
            Direction = direction;
            RailCrossing = railCrossing;
            DirectDirectionLaneCount = directDirectionLaneCount;
            ReverseDirectionLaneCount = reverseDirectionLaneCount;
            DirectDirectionDedicatedLaneCount = directDirectionDedicatedLaneCount;
            ReverseDirectionDedicatedLaneCount = reverseDirectionDedicatedLaneCount;
            HasPublicTransport = hasPublicTransport;
            TurnRestrictions = turnRestrictions;
            Geometry = geometry;
            Comment = comment;
            DistrictId = districtId;
            StreetId = streetId;
            UpdateToken = token;
        }

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

        public void UpdateOrFail(string comment, int maxSpeed, string turnRestrictions)
        {
            Comment = comment;
            MaxSpeed = maxSpeed;
            TurnRestrictions = turnRestrictions;

            this.ThrowIfInvalid();
        }
    }
}