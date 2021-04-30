namespace DanhoLibrary.EFController
{
    public abstract class Repository<Entity> : BaseRepository<Entity> where Entity : HasID
    {
        public Repository(DanhoDBContext context) : base(context) { }

        protected int SaveChanges() => _context.SaveChanges();

        public virtual new Entity Add(Entity entity = null)
        {
            entity = base.Add(entity);
            SaveChanges();
            return entity;
        }
        public virtual new Entity Update(Entity entity)
        {
            entity = base.Update(entity);
            SaveChanges();
            return entity;
        }
        public virtual new void Delete(Entity entity)
        {
            base.Delete(entity);
            SaveChanges();
        }
    }
}
