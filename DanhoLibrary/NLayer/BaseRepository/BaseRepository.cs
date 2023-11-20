using DanhoLibrary.NLayer.BaseRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DanhoLibrary.NLayer;

public abstract partial class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
{
    /// <summary>
    /// Set of <see cref="TEntity"/> in database.
    /// This is used to easily handle CRUD operations without needing to know the exact entity from DbContext
    /// </summary>
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly DbContext _context;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public bool Exists(TId? id)
    {
        try
        {
            return Get(id) is not null;
        }
        catch (Exception) // ArgumentNullException or EntityNotFoundException
        {
            return false;
        }
    }
    public bool Exists(TEntity? entity) => entity is not null && Exists(entity.Id);

    public void Detatch(TEntity entity) => _context.Entry(entity).State = EntityState.Detached;

    protected EntityNotFoundException<TEntity, TId> EntityNotFound(TEntity? entity) => new(nameof(entity), entity);
}
