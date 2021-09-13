using System;
using System.Threading;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Bases
{
    public class VehicleBase : BaseModel
    {
        protected VehicleBase()
        {
        }

        public VehicleBase(string nameRu, string nameEn, string nameKk, double polygon, string comment, string token)
        {
            NameRu = nameRu;
            NameEn = nameEn;
            NameKk = nameKk;
            Polygon = polygon;
            Comment = comment;
            UpdateToken = token;
            ValidFrom = DateTimeOffset.Now;
            ValidTo = DateTimeOffset.Now;
        }

        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public double Polygon { get; set; }

        public long ProviderId { get; set; }

        public string Comment { get; set; }

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