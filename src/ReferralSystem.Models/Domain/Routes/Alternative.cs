using System;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Alternative : BaseModel
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public string FullNameRu { get; set; }

        public string FullNameEn { get; set; }

        public string FullNameKk { get; set; }

        public int VehicleCount { get; set; }

        public int PeakInterval { get; set; }

        public int OffPeakInterval { get; set; }

        public long RouteId { get; set; }

        public long VehicleTypeId { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset ValidTo { get; set; }
    }
}