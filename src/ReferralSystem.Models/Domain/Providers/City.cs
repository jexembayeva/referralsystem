using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Providers
{
    public class City : BaseModel
    {
        protected City()
        {
        }

        public City(
            string nameRu,
            string nameKk,
            string nameEn,
            long regionId,
            string comment)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            RegionId = regionId;
            Comment = comment;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public long RegionId { get; protected set; }

        public string Comment { get; protected set; }

        public void UpdateOrFail(
            string nameRu,
            string nameKk,
            string nameEn,
            long regionId,
            string comment)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            RegionId = regionId;
            Comment = comment;

            this.ThrowIfInvalid();
        }
    }
}