using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Segments
{
    public class Segment : BaseModel, IHasFromToDates
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
            long streetId)
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
        }

        public int Length { get; protected set; }

        public int LineCount { get; protected set; }

        public bool ParkingAllowed { get; protected set; }

        public int MaxSpeed { get; protected set; }

        public bool OneWay { get; protected set; }

        public int Direction { get; protected set; }

        public bool RailCrossing { get; protected set; }

        public long DedicatedLaneId { get; protected set; }

        public int DirectDirectionLaneCount { get; protected set; }

        public int ReverseDirectionLaneCount { get; protected set; }

        public int DirectDirectionDedicatedLaneCount { get; protected set; }

        public int ReverseDirectionDedicatedLaneCount { get; protected set; }

        public bool HasPublicTransport { get; protected set; }

        public string TurnRestrictions { get; protected set; }

        public double Geometry { get; protected set; }

        public string Comment { get; protected set; }

        public long DistrictId { get; protected set; }

        public long StreetId { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(string comment, int maxSpeed, string turnRestrictions)
        {
            Comment = comment;
            MaxSpeed = maxSpeed;
            TurnRestrictions = turnRestrictions;

            this.ThrowIfInvalid();
        }
    }
}