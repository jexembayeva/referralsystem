using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Route : BaseModel
    {
        protected Route()
        {
        }

        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public string FullNameRu { get; set; }

        public string FullNameEn { get; set; }

        public string FullNameKk { get; set; }

        public double Distance { get; set; }

        public string Comment { get; set; }

        public string OpenReason { get; set; }

        public string CloseReason { get; set; }
    }
}