using System.Threading;
using ReferralSystem.Models.Domain.Bases;

namespace ReferralSystem.Domain.Dtos.Bases
{
    public class VehicleBaseDto : BaseModelDto
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public double Polygon { get; set; }

        public long ProviderId { get; set; }

        public string Comment { get; set; }

        public VehicleBase NewBasePlatform(CancellationToken cancellationToken)
        {
            return new VehicleBase(
                nameEn: NameEn,
                nameRu: NameRu,
                nameKk: NameKk,
                polygon: Polygon,
                comment: Comment,
                token: cancellationToken.ToString());
        }
    }
}