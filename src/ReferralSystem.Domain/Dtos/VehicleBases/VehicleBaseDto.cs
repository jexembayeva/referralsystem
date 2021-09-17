using ReferralSystem.Models.Domain.VehicleBases;

namespace ReferralSystem.Domain.Dtos.VehicleBases
{
    public class VehicleBaseDto : BaseModelDto
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public double Polygon { get; set; }

        public long ProviderId { get; set; }

        public string Comment { get; set; }

        public VehicleBase NewBasePlatform()
        {
            return new VehicleBase(
                nameEn: NameEn,
                nameRu: NameRu,
                nameKk: NameKk,
                polygon: Polygon,
                comment: Comment);
        }
    }
}