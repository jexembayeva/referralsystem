using System;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Route : BaseModel
    {
        protected Route()
        {
        }

        public Route(string nameRu, string nameEn, string nameKk, string fullNameRu, string fullNameEn, string fullNameKk, double distance, string comment, string openReason, string closeReason, string token)
        {
            NameRu = nameRu;
            NameEn = nameEn;
            NameKk = nameKk;
            FullNameRu = fullNameRu;
            FullNameEn = fullNameEn;
            FullNameKk = fullNameKk;
            Distance = distance;
            Comment = comment;
            OpenReason = openReason;
            CloseReason = closeReason;
            UpdateToken = token;
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