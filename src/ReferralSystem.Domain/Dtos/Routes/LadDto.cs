using System;
using ReferralSystem.Models.Domain.Routes;
using Utils.Dates;
using Utils.Enums;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class LadDto : BaseModelDto, IHasFromToDates
    {
        public int Direction { get; set; }

        public int Length { get; set; }

        public int Stops { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int TransitTime { get; set; }

        public long AlternativeId { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

        public Lad NewLad()
        {
            return new Lad(
                name: Name,
                direction: Direction,
                comment: Comment,
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
