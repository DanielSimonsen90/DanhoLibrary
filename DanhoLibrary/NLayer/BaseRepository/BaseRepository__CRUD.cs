﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using DanhoLibrary.Extensions;
using DanhoLibrary.NLayer.BaseRepository.Interfaces;

namespace DanhoLibrary.NLayer;
public abstract partial class BaseRepository<TEntity, TId> : IBaseRepository__CRUD<TEntity, TId>
    where TEntity : BaseEntity<TId>
{
    #region Add
    public virtual void Add(TEntity entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        _dbSet.Add(entity);
    }
    public virtual async Task AddAsync(TEntity entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddAsync(entity);
    }
    #endregion

    #region GetAll
    public virtual IEnumerable<TEntity> GetAll() => _dbSet.ToList() ?? new List<TEntity>();
    public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate).ToList();
    #endregion

    #region Get
    public virtual TEntity Get(TId? id)
    {
        if (IsIdInvalid(id)) throw new ArgumentNullException(nameof(id));

        TEntity? entity = _dbSet.Find(id);
        if (entity is null) throw EntityNotFound(entity);
        
        return entity;
    }
    public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate) => _dbSet.FirstOrDefault(predicate);
    public virtual TEntity GetWithRelations(TId? id, params Expression<Func<TEntity, object?>>[] relations) => relations
        .Aggregate(_dbSet.AsQueryable(), (query, relation) => query.Include(relation))
        .FirstOrDefault(e => e.Id!.Equals(id));
    public virtual async Task<TEntity> GetAsync(TId? id)
    {
        if (IsIdInvalid(id)) throw new ArgumentException(nameof(id));

        TEntity? entity = await _dbSet.FindAsync(id);
        if (entity is null) throw EntityNotFound(entity);

        return entity;
    }
    protected virtual bool IsIdInvalid(TId? id)
    {
        bool idIsNullOrDefault = id is null || id.Equals(default(TId));
        bool invalidNumber = id is int numId && numId < 0;
        bool invalidString = id is string stringId && string.IsNullOrEmpty(stringId);
        bool invalidGuid = id is Guid guidId && guidId == Guid.Empty;
        bool[] validations = { idIsNullOrDefault, invalidNumber, invalidString, invalidGuid };

        return validations.ContainsAny(true);
    }
    #endregion

    #region Read
    public virtual void Read(TId id, Action<TEntity> callback)
    {
        TEntity? entity = Get(id);
        if (entity is null) throw EntityNotFound(entity);

        callback(entity);
    }
    public virtual async Task ReadAsync(TId id, Func<TEntity, Task> callback)
    {
        TEntity? entity = Get(id);
        if (entity is null) throw EntityNotFound(entity);

        await callback(entity);
    }
    #endregion

    #region Update
    public virtual void Update(TEntity entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        if (!Exists(entity)) throw EntityNotFound(entity);
        
        _dbSet.Update(entity);
    }
    #endregion

    #region Delete
    public virtual void Delete(TId id)
    {
        TEntity? entity = Get(id);
        if (entity is null) throw EntityNotFound(entity);

        Delete(entity);
    }
    public virtual void Delete(TEntity entity)
    {
        if (entity is null) throw EntityNotFound(entity);

        _dbSet.Remove(entity);
    }
    #endregion
}