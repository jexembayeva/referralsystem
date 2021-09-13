using System;
using System.Threading;
using ReferralSystem.Models.Domain.Segments;

namespace ReferralSystem.Domain.Dtos.Segments
{
    public class SegmentDto : BaseModelDto
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

        public Segment NewSegment()
        {
            return new Segment(
                            length: Length,
                            lineCount: LineCount,
                            parkingAllowed: ParkingAllowed,
                            maxSpeed: MaxSpeed,
                            oneWay: OneWay,
                            direction: Direction,
                            railCrossing: RailCrossing,
                            directDirectionLaneCount: DirectDirectionLaneCount,
                            reverseDirectionLaneCount: ReverseDirectionLaneCount,
                            directDirectionDedicatedLaneCount: DirectDirectionDedicatedLaneCount,
                            reverseDirectionDedicatedLaneCount: ReverseDirectionDedicatedLaneCount,
                            hasPublicTransport: HasPublicTransport,
                            turnRestrictions: TurnRestrictions,
                            geometry: Geometry,
                            comment: Comment,
                            districtId: DistrictId,
                            streetId: StreetId);
        }
    }
}
