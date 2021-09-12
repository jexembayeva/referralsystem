using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Stop
{
    public class Stop : BaseModel
    {
        protected Stop()
        {
        }

        public Stop(string nameRu, string nameEn, string nameKk, double? longitude, double? latitude, short? direction, string comment, string token)
        {
            NameEn = nameEn;
            NameRu = nameRu;
            NameKk = nameKk;
            Longitude = longitude;
            Latitude = latitude;
            Direction = direction;
            Comment = comment;
            UpdateToken = token;
        }

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

        public void UpdateOrFail(string nameEn, string nameKk, string nameRu)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;

            this.ThrowIfInvalid();
        }
    }
}