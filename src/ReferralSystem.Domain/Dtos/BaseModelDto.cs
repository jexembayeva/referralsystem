using System;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos
{
    public abstract class BaseModelDto : IBaseModel, IHasFromToDates
    {
        public long Id { get; set; }

        public long AuthorId { get; set; }

        public long EditorId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }
    }
}