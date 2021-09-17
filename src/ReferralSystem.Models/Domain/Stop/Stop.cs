using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Stop
{
    public class Stop : BaseModel, IHasFromToDates
    {
        protected Stop()
        {
        }

        public Stop(string nameRu, string nameEn, string nameKk, double? longitude, double? latitude, short? direction, string comment)
        {
            NameEn = nameEn;
            NameRu = nameRu;
            NameKk = nameKk;
            Longitude = longitude;
            Latitude = latitude;
            Direction = direction;
            Comment = comment;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public double? Longitude { get; protected set; }

        public double? Latitude { get; protected set; }

        public short? Direction { get; protected set; }

        public string Comment { get; protected set; }

        public bool HasStopZone { get; protected set; }

        public bool HasLongStopZone { get; protected set; }

        public int? DistrictId { get; protected set; }

        public int? SegmentId { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(string nameEn, string nameKk, string nameRu)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;

            this.ThrowIfInvalid();
        }
    }
}