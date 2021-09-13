using System;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class RouteSchedule : BaseModel
    {
        protected RouteSchedule()
        {
        }

        public string Name { get; protected set; }

        public long RouteId { get; protected set; }

        public string Comment { get; protected set; }

        public DateTimeOffset StartTime { get; protected set; }

        public DateTimeOffset EndTime { get; protected set; }

        public DateTime Interval { get; protected set; }

        public int TimeLineCount { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset ValidTo { get; protected set; }
    }
}