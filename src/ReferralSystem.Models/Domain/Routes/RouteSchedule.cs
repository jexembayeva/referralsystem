using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Attributes;
using Utils.Enums;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class RouteSchedule : BaseModel, IHasFromToDates
    {
        protected RouteSchedule()
        {
        }

        public RouteSchedule(string name, string comment, int timeLineCount)
        {
            Name = name;
            Comment = comment;
            TimeLineCount = timeLineCount;
        }

        public string Name { get; protected set; }

        public long RouteId { get; protected set; }

        public string Comment { get; protected set; }

        public DateTimeOffset StartTime { get; protected set; }

        public DateTimeOffset EndTime { get; protected set; }

        public DateTimeOffset Interval { get; protected set; }

        public int TimeLineCount { get; protected set; }

        [NotDefaultValue]
        public DayType DayType { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(string name, string comment, int timeLineCount)
        {
            Name = name;
            Comment = comment;
            TimeLineCount = timeLineCount;

            this.ThrowIfInvalid();
        }
    }
}