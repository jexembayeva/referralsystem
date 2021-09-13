using System;

namespace Utils.Interfaces
{
    public interface IHasDates
    {
        DateTimeOffset? CreatedAt { get; }

        DateTimeOffset? UpdatedAt { get; }
    }
}