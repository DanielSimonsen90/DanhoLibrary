using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanhoLibrary.EFController
{
    public abstract class BaseController<Entity> where Entity : HasID
    {
        protected readonly DanhoDBContext _context;
        public BaseController(DanhoDBContext context) => _context = context;

        protected virtual void IfNull(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(entity)} must not be null");
        }

        /// <summary>
        /// Handle if <paramref name="entity"/> is null - validate if something is missing from entity, throw error but always return entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract Entity AddIfNull(Entity entity);
        public virtual Entity Add(Entity entity = null)
        {
            entity = AddIfNull(entity);

            _context.Set<Entity>().Add(entity);
            return entity;
        }

        public virtual IList<Entity> GetMultiple(Func<Entity, bool> predicate = null) => predicate != null ? _context.Set<Entity>().Where(predicate).ToList() : _context.Set<Entity>().ToList();
        public virtual Entity Get(Func<Entity, bool> predicate) => GetMultiple(predicate)?.FirstOrDefault();
        public virtual Entity Get(int id) => Get(c => c.ID == id);

        public virtual Entity Update(Entity entity)
        {
            IfNull(entity);

            _context.StateAsModified(entity);
            return entity;
        }
        public virtual void Delete(Entity entity)
        {
            IfNull(entity);

            _context.StateAsDeleted(entity);
        }
        public virtual void Delete(int id) => Delete(Get(id));
    }
}
