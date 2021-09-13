using System;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class RoutePlan : BaseModel
    {
        protected RoutePlan()
        {
        }

        public string Name { get; protected set; }

        public long RouteId { get; protected set; }

        public int RoundCount { get; protected set; }

        public DateTimeOffset StartTime { get; protected set; }

        public DateTimeOffset EndTime { get; protected set; }

        public int Interval { get; protected set; }

        public string Comment { get; protected set; }

        public int DurationAB { get; protected set; }

        public int DurationBA { get; protected set; }

        public int Capacity { get; protected set; }

        public int MaxStopTime { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset ValidTo { get; protected set; }
    }
}