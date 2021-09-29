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
    public class Lad : BaseModel, IHasFromToDates
    {
        protected Lad()
        {
        }

        public Lad(
            string name,
            int direction,
            string comment,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo,
            Status status)
        {
            Name = name;
            Direction = direction;
            Comment = comment;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Status = status;
        }

        public int Direction { get; protected set; }

        public int Length { get; protected set; }

        public int Stops { get; protected set; }

        public string Name { get; protected set; }

        public string Comment { get; protected set; }

        public int TransitTime { get; protected set; }

        public long AlternativeId { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        [NotDefaultValue]
        public Status Status { get; protected set; }

        [Write(false)]
        public bool Active => Status == Status.Active;

        public void UpdateOrFail(string name, int direction, string comment)
        {
            Name = name;
            Direction = direction;
            Comment = comment;

            this.ThrowIfInvalid();
        }

        public void UpdateToMakeOutdatedOrFail(DateTimeOffset validTo)
        {
            ValidTo = validTo;
            Status = Status.Outdated;

            if (this.RangeReversed(true))
            {
                throw new BadRequestException($"Previous {nameof(Lad)} becomes invalid due to this operation");
            }

            this.ThrowIfDateRangeIsNotValid(true);
            this.ThrowIfDateRangeIsOutOfAllowedLimits();
            this.ThrowIfInvalid();
        }
    }
}