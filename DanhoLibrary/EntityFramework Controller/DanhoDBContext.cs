using Microsoft.EntityFrameworkCore;

namespace DanhoLibrary.EFController
{
    public class DanhoDBContext : DbContext
    {
        public void StateAsModified<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Modified;
        public void StateAsDeleted<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Deleted;
        public int ExecuteSqlCommand(string sql, params object[] parameters) => Database.ExecuteSqlRaw(sql, parameters);
    }
}
