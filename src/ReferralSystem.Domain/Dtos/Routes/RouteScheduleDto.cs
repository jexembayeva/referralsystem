using System;
using ReferralSystem.Models.Domain.Routes;
using Utils.Attributes;
using Utils.Enums;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class RouteScheduleDto : BaseModelDto
    {
        public string Name { get; set; }

        public long RouteId { get; set; }

        public string Comment { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public DateTime Interval { get; set; }

        public int TimeLineCount { get; set; }

        [NotDefaultValue]
        public DayType DayType { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

        public RouteSchedule NewRouteSchedule()
        {
            return new RouteSchedule(
                name: Name,
                comment: Comment,
                timeLineCount: TimeLineCount);
        }
    }
}
