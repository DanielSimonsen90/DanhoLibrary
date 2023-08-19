using System;

namespace DanhoLibrary.NLayer
{
    /// <summary>
    /// Throw when <typeparamref name="TEntity"/> is not in database.
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TId">Id type of entity</typeparam>
    public class EntityNotFoundException<TEntity, TId> : Exception where TEntity : BaseEntity<TId>
    {
        /// <param name="entityName">nameof(entity)</param>
        /// <param name="entity">The entity.. which is null</param>
        public EntityNotFoundException(string entityName, TEntity? entity) : base($"{entityName} was not found.")
        {
            Entity = entity;
        }

        /// <summary>
        /// The entity that was not found... which is null? I just realized how useless this is, but we're keeping it.
        /// </summary>
        public TEntity? Entity { get; set; }
    }
}
