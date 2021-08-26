using System;

namespace Utils.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        private ResourceNotFoundException(string message)
            : base(message)
        {
        }

        public static ResourceNotFoundException CreateFromEntity<TEntity>(long id)
        {
            return new ResourceNotFoundException($"Did not find any {typeof(TEntity).Name} by id={id}");
        }
    }
}