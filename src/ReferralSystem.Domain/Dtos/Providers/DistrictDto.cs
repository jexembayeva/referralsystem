using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Dtos.Providers
{
    public class DistrictDto : BaseModelDto
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public double Polygon { get; set; }

        public string Color { get; set; }

        public long RegionId { get; set; }

        public District NewDistrict()
        {
            return new District(
                nameRu: NameRu,
                nameEn: NameEn,
                nameKk: NameKk);
        }
    }
}