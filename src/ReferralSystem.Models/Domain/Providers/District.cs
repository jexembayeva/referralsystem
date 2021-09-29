using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Providers
{
    public class District : BaseModel
    {
        protected District()
        {
        }

        public District(
            string nameRu,
            string nameKk,
            string nameEn,
            double polygon,
            string color,
            long regionId)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            Polygon = polygon;
            Color = color;
            RegionId = regionId;
        }

        public District(string nameRu, string nameKk, string nameEn,  IEnumerable<Segment> segments)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            Segments = segments;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public double Polygon { get; protected set; }

        public string Color { get; protected set; }

        public long RegionId { get; protected set; }

        [Write(false)]
        public IEnumerable<Segment> Segments { get; protected set; }

        public Segment ActiveSegmentOrNull()
        {
            return Segments.FirstOrDefault(x => x.Active);
        }

        public void UpdateOrFail(
            string nameRu,
            string nameKk,
            string nameEn,
            double polygon,
            string color,
            long regionId)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            Polygon = polygon;
            Color = color;
            RegionId = regionId;

            this.ThrowIfInvalid();
        }
    }
}