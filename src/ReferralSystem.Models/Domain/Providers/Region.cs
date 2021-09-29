using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Region : BaseModel
    {
        protected Region()
        {
        }

        public Region(
            string nameRu,
            string nameKk,
            string nameEn,
            string comment)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            Comment = comment;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public string Comment { get; protected set; }

        public void UpdateOrFail(
            string nameRu,
            string nameKk,
            string nameEn,
            string comment)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            Comment = comment;

            this.ThrowIfInvalid();
        }
    }
}