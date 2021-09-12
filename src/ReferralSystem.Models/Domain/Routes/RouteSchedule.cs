using System;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class RouteSchedule : BaseModel
    {
        public string Name { get; set; }

        public long RouteId { get; set; }

        public string Comment { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public DateTime Interval { get; set; }

        public int TimeLineCount { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset ValidTo { get; set; }
    }
}