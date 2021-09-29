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
    public class RoutePlan : BaseModel, IHasFromToDates
    {
        protected RoutePlan()
        {
        }

        public RoutePlan(
            string name,
            long routeId,
            int roundCount,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            int interval,
            string comment,
            int durationAB,
            int durationBA,
            int capacity,
            int maxStopTime,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo,
            Status status)
        {
            Name = name;
            RouteId = routeId;
            RoundCount = roundCount;
            StartTime = startTime;
            EndTime = endTime;
            Interval = interval;
            Comment = comment;
            DurationAB = durationAB;
            DurationBA = durationBA;
            Capacity = capacity;
            MaxStopTime = maxStopTime;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Status = status;
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

        public DateTimeOffset? ValidTo { get; protected set; }

        [NotDefaultValue]
        public Status Status { get; protected set; }

        [Write(false)]
        public bool Active => Status == Status.Active;

        public void UpdateOrFail(
            string name,
            long routeId,
            int roundCount,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            int interval,
            string comment,
            int durationAB,
            int durationBA,
            int capacity,
            int maxStopTime,
            DateTimeOffset? validTo)
        {
            Name = name;
            RouteId = routeId;
            RoundCount = roundCount;
            StartTime = startTime;
            EndTime = endTime;
            Interval = interval;
            Comment = comment;
            DurationAB = durationAB;
            DurationBA = durationBA;
            Capacity = capacity;
            MaxStopTime = maxStopTime;
            ValidTo = validTo;

            this.ThrowIfInvalid();
        }

        public void UpdateToMakeOutdatedOrFail(DateTimeOffset validTo)
        {
            ValidTo = validTo;
            Status = Status.Outdated;

            if (this.RangeReversed(true))
            {
                throw new BadRequestException($"Previous {nameof(RoutePlan)} becomes invalid due to this operation");
            }

            this.ThrowIfDateRangeIsNotValid(true);
            this.ThrowIfDateRangeIsOutOfAllowedLimits();
            this.ThrowIfInvalid();
        }
    }
}