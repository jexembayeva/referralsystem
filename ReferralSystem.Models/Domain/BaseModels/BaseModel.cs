﻿using System;
using Utils.Interfaces;

namespace ReferralSystem.Models.Domain.BaseModels
{
    public class BaseModel : IBaseModel
    {
        public long Id { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public bool IsNew() => Id == default(long);
    }
}