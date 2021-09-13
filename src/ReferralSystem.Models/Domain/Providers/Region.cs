using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Region : BaseModel
    {
        protected Region()
        {
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public string Comment { get; protected set; }
    }
}