using System;
using System.Threading;
using ReferralSystem.Models.Domain.Stop;

namespace ReferralSystem.Domain.Dtos.Stops
{
    public class StopDto : BaseModelDto
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public short? Direction { get; set; }

        public string Comment { get; set; }

        public bool HasStopZone { get; set; }

        public bool HasLongStopZone { get; set; }

        public int? DistrictId { get; set; }

        public int? SegmentId { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset ValidTo { get; set; }

        public Stop NewStop(CancellationToken cancellationToken)
        {
            return new Stop(
                nameEn: NameEn,
                nameKk: NameKk,
                nameRu: NameRu,
                longitude: Longitude,
                latitude: Latitude,
                direction: Direction,
                comment: Comment,
                token: cancellationToken.ToString());
        }
    }
}