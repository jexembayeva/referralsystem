using System;

namespace Utils.Interfaces
{
    public interface IHasFromToDates
    {
        DateTimeOffset ValidFrom { get; }

        DateTimeOffset? ValidTo { get; }
    }
}