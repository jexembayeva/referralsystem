using System;
using ReferralSystem.Models.Domain.Routes;
using Utils.Attributes;
using Utils.Dates;
using Utils.Enums;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class RouteScheduleDto : BaseModelDto, IHasFromToDates
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
                routeId: RouteId,
                comment: Comment,
                startTime: StartTime,
                endTime: EndTime,
                interval: Interval,
                timeLineCount: TimeLineCount,
                dayType: DayType,
                validFrom: ValidFrom,
                validTo: ValidTo,
                status: Status.Active);
        }

        public void CorrectDates()
        {
            ValidFrom = this.Since().StartOfTheDay();
            ValidTo = this.ToAsDateOrNull()?.EndOfTheDay();
        }
    }
}
