using System.Reflection.Metadata;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Devices
{
    public class FirmWare : BaseModel
    {
        public string Name { get; set; }

        public string Config { get; set; }

        public string Comment { get; set; }
    }
}