using System;

namespace Utils.Exceptions
{
    public class InvalidDateRangeException : InvalidOperationException
    {
        public InvalidDateRangeException(string message)
            : base(message)
        {
        }

        public InvalidDateRangeException()
            : this("ValidTo date is null")
        {
        }

        public static InvalidDateRangeException CreateFromEntity<T>(long id)
        {
            return new InvalidDateRangeException($"{typeof(T).Name} #Id:{id} has no ValidTo date");
        }
    }
}