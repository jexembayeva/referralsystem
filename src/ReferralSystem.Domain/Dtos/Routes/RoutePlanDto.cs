using System;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class RoutePlanDto : BaseModelDto
    {
        public string Name { get; set; }

        public long RouteId { get; set; }

        public int RoundCount { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public int Interval { get; set; }

        public string Comment { get; set; }

        public int DurationAB { get; set; }

        public int DurationBA { get; set; }

        public int Capacity { get; set; }

        public int MaxStopTime { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

        public RoutePlan NewRoutePlan()
        {
            return new RoutePlan(
                name: Name,
                comment: Comment,
                routeId: RouteId);
        }
    }
}
