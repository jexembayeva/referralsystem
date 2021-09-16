using System;
using Utils.Interfaces;

namespace ReferralSystem.Models.Domain.BaseModels
{
    public class BaseModel : IBaseModel
    {
        public long Id { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        public long AuthorId { get; protected set; }

        public long EditorId { get; protected set; }
    }
}