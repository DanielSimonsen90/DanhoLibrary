using DanhoLibrary.NLayer.BaseRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DanhoLibrary.NLayer;

public abstract partial class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
{
    /// <summary>
    /// Set of <see cref="TEntity"/> in database.
    /// This is used to easily handle CRUD operations without needing to know the exact entity from DbContext
    /// </summary>
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public bool Exists(TId? id) => Get(id) is not null;
    public bool Exists(TEntity? entity) => entity is not null && Exists(entity.Id);

    protected EntityNotFoundException<TEntity, TId> EntityNotFound(TEntity? entity) => new(nameof(entity), entity);
}
