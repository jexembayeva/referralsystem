using System;

namespace Utils.Exceptions
{
    public class BadRequestException : InvalidOperationException
    {
        public BadRequestException()
            : base("Bad Request")
        {
        }

        protected BadRequestException(string message)
            : base(message)
        {
        }
    }
}