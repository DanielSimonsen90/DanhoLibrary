using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanhoLibrary.EFController
{
    public abstract class RepositoryAsync<Entity> : BaseRepository<Entity> where Entity : HasID
    {
        public RepositoryAsync(DanhoDBContext context) : base(context) { }

        protected Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public async virtual new Task<Entity> Add(Entity entity = null)
        {
            entity = base.Add(entity);
            await SaveChangesAsync();
            return entity;
        }
        public async virtual new Task<Entity> Update(Entity entity)
        {
            entity = base.Update(entity);
            await SaveChangesAsync();
            return entity;
        }
        public async virtual new Task Delete(Entity entity) => await new Task(async () =>
        {
            base.Delete(entity);
            await SaveChangesAsync();
        });
        public async virtual new Task<IList<Entity>> GetMultiple(Func<Entity, bool> predicate = null) => await new Task<IList<Entity>>(() => base.GetMultiple(predicate));
        public async virtual new Task<Entity> Get(Func<Entity, bool> predicate) => await new Task<Entity>(() => base.Get(predicate));
        public async virtual new Task<Entity> Get(int id) => await new Task<Entity>(() => base.Get(id));
        public async virtual new Task Delete(int id) => await new Task(() => base.Delete(id));
    }
}
