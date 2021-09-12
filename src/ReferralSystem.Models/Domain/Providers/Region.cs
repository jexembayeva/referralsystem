using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Region : BaseModel
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public string Comment { get; set; }
    }
}