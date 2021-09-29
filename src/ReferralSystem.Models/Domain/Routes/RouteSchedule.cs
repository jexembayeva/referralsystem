using System;
using Dapper.Contrib.Extensions;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Attributes;
using Utils.Enums;
using Utils.Exceptions;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class RouteSchedule : BaseModel, IHasFromToDates
    {
        protected RouteSchedule()
        {
        }

        public RouteSchedule(
            string name,
            long routeId,
            string comment,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            DateTimeOffset interval,
            int timeLineCount,
            DayType dayType,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo,
            Status status)
        {
            Name = name;
            RouteId = routeId;
            Comment = comment;
            StartTime = startTime;
            EndTime = endTime;
            Interval = interval;
            TimeLineCount = timeLineCount;
            DayType = dayType;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Status = status;
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

        [NotDefaultValue]
        public Status Status { get; protected set; }

        [Write(false)]
        public bool Active => Status == Status.Active;

        public void UpdateOrFail(
            string name,
            long routeId,
            string comment,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            DateTimeOffset interval,
            int timeLineCount,
            DayType dayType,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            Name = name;
            RouteId = routeId;
            Comment = comment;
            StartTime = startTime;
            EndTime = endTime;
            Interval = interval;
            TimeLineCount = timeLineCount;
            DayType = dayType;
            ValidFrom = validFrom;
            ValidTo = validTo;

            this.ThrowIfInvalid();
        }

        public void UpdateToMakeOutdatedOrFail(DateTimeOffset validTo)
        {
            ValidTo = validTo;
            Status = Status.Outdated;

            if (this.RangeReversed(true))
            {
                throw new BadRequestException($"Previous {nameof(RouteSchedule)} becomes invalid due to this operation");
            }

            this.ThrowIfDateRangeIsNotValid(true);
            this.ThrowIfDateRangeIsOutOfAllowedLimits();
            this.ThrowIfInvalid();
        }
    }
}