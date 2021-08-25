using Utils.Exceptions;

namespace Utils.Validators
{
    public static class EntityValidatorExtensions
    {
        /// <summary>
        /// Asserts that a model entity is valid by it's annotation validation attributes.
        /// </summary>
        /// <typeparam name="T">Generic.</typeparam>
        /// <param name="entity">Entity instance.</param>
        /// <returns>The entity.</returns>
        /// <exception cref="EntityInvalidException">If the entity is not valid.</exception>
        public static T ThrowIfInvalid<T>(this T entity)
        {
            new EntityValidator<T>(entity).ThrowIfInvalid();
            return entity;
        }
    }
}