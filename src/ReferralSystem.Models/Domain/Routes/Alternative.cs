using System;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Alternative : BaseModel
    {
        protected Alternative()
        {
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public string FullNameRu { get; protected set; }

        public string FullNameEn { get; protected set; }

        public string FullNameKk { get; protected set; }

        public int VehicleCount { get; protected set; }

        public int PeakInterval { get; protected set; }

        public int OffPeakInterval { get; protected set; }

        public long RouteId { get; protected set; }

        public long VehicleTypeId { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset ValidTo { get; protected set; }
    }
}