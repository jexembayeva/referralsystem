using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Dtos.Providers
{
    public class DistrictDto : BaseModelDto
    {
        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public double Polygon { get; protected set; }

        public string Color { get; protected set; }

        public long RegionId { get; protected set; }

        public District NewDistrict()
        {
            return new District(
                nameRu: NameRu,
                nameEn: NameEn,
                nameKk: NameKk);
        }
    }
}