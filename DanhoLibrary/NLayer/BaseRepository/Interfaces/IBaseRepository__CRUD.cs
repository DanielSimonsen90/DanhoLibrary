using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DanhoLibrary.NLayer.BaseRepository.Interfaces;

internal interface IBaseRepository__CRUD<TEntity, TId>
    where TEntity : BaseEntity<TId>
{
    /// <summary>
    /// Add <typeparamref name="TEntity"/> to database.
    /// </summary>
    /// <param name="entity">Entity to add.</param>
    /// <returns>True if sucessful.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entity"/> is null</exception>
    TEntity Add(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity);

    /// <summary>
    /// Get all entities from database.
    /// </summary>
    /// <returns>Collection of entities found.</returns>
    IEnumerable<TEntity> GetAll();
    /// <summary>
    /// Get all entities from database, filtered by <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">Filter entities by boolean. If true, include <typeparamref name="TEntity"/> in collection.</param>
    /// <returns>Collection of entities found and filtered.</returns>
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Get an <typeparamref name="TEntity"/> by id.
    /// </summary>
    /// <param name="id">Id of the <typeparamref name="TEntity"/>.</param>
    /// <returns><typeparamref name="TEntity"/> if entity with <paramref name="id"/> was found.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="id"/> is null or invalid</exception>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">If found entity is null</exception>
    TEntity Get(TId? id);
    /// <summary>
    /// Get an <typeparamref name="TEntity"/> filtered by <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">Get <typeparamref name="TEntity"/> by boolean. If true, return <typeparamref name="TEntity"/>.</param>
    /// <returns>Entity found by <paramref name="predicate"/>, if any found.</returns>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">If found entity is null</exception>
    TEntity Get(Expression<Func<TEntity, bool>> predicate);
    /// <summary>
    /// Get entity by <paramref name="id"/>, including relations mapped through <paramref name="relations"/>.
    /// </summary>
    /// <param name="id">Id of the <typeparamref name="TEntity"/> to get.</param>
    /// <param name="relations">Relations to include from entity. Relations being non-primitive types from entity model.</param>
    /// <returns>Entity with relations.</returns>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">If found entity is null</exception>
    TEntity GetWithRelations(TId? id, params Expression<Func<TEntity, object?>>[] relations);
    /// <summary>
    /// <see cref="Get(TId)"/> but async
    /// </summary>
    /// <param name="id">Id of the entity to get asyncronously</param>
    /// <returns>The entity</returns>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">If entity wasn't found</exception>
    Task<TEntity> GetAsync(TId? id);

    /// <summary>
    /// Get the entity from database, but don't return it. Not sure when you would use this, but it's here
    /// </summary>
    /// <param name="id">The id of the <typeparamref name="TEntity"/></param>
    /// <param name="callback">Callback where <typeparamref name="TEntity"/> matching <typeparamref name="TId"/> is provided</param>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">Thrown if <typeparamref name="TEntity"/> was not found in database.</exception>
    void Read(TId id, Action<TEntity> callback);
    /// <summary>
    /// Get the entity from database, but don't return it - async edition
    /// </summary>
    /// <param name="id">Id of the entity to read</param>
    /// <param name="callback">Callback to run when entity is found</param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">If <typeparamref name="TEntity"/> was found with provided <paramref name="id"/></exception>
    Task ReadAsync(TId id, Func<TEntity, Task> callback);

    /// <summary>
    /// Update <paramref name="entity"/> in database
    /// </summary>
    /// <param name="entity"><typeparamref name="TEntity"/> to update.</param>
    /// <returns>If update succeeded.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="entity"/> is null.</exception>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">Thrown if <paramref name="entity"/> was not found in database.</exception>
    void Update(TEntity entity);
    
    /// <summary>
    /// Delete <paramref name="entity"/> from database
    /// </summary>
    /// <param name="entity"><typeparamref name="TEntity"/> to delete.</param>
    /// <returns>True if deleted.</returns>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">Thrown if <paramref name="entity"/> was not found in database.</exception>
    void Delete(TEntity entity);
    /// <summary>
    /// Delete entity matching <paramref name="id"/> from database.
    /// </summary>
    /// <param name="id">If of the <typeparamref name="TEntity"/> to delete.</param>
    /// <returns>True if deleted.</returns>
    /// <exception cref="EntityNotFoundException{TEntity, TId}">Thrown if <paramref name="entity"/> was not found in database.</exception>
    void Delete(TId id);
}
