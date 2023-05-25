using DanhoLibrary.Collections.Interfaces;
using DanhoLibrary.Extensions;
using System;
using System.Collections.Generic;

namespace DanhoLibrary.Collections
{
    public abstract class Crud<Collection, Item> : ICrud<Collection, Item> 
        where Collection : IList<Item>
        where Item : ICrudItem
    {
        protected Collection InnerCollection { get; set; }

        public virtual Collection Create(Item item)
        {
            if (item == null) throw new ArgumentNullException();
            InnerCollection.Add(item);
            return InnerCollection;
        }
        public Item Read(int id) => InnerCollection.Find(i => i.ID == id);
        public Item Update(int id, Item updatedItem)
        {
            Item item = Read(id);
            if (item == null) throw NotFound(id);

            int itemIndex = InnerCollection.IndexOf(item);
            InnerCollection[itemIndex] = updatedItem;

            return item;
        }
        public Collection Delete(Item item)
        {
            int itemIndex = InnerCollection.IndexOf(item);
            if (itemIndex == -1) throw NotFound(item);

            InnerCollection.Remove(item);
            return InnerCollection;
        }
        public Collection Delete(int id)
        {
            Item item = Read(id);
            if (item == null) throw NotFound(id);
            return Delete(item);
        }

        protected static ItemNotFoundException<Item> NotFound(int id) => new ItemNotFoundException<Item>($"The value \"{id}\" is not an id in the inner collection.");
        protected static ItemNotFoundException<Item> NotFound(Item item) => new ItemNotFoundException<Item>($"The item provided is not in the inner collection.", item);
    }

    [Serializable]
    public class ItemNotFoundException<Item> : Exception where Item : ICrudItem
    {
        public Item ItemObject { get; set; }

        public ItemNotFoundException() { }
        public ItemNotFoundException(string message) : base(message) { }
        public ItemNotFoundException(string message, Item item) : base(message) => ItemObject = item;
        public ItemNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected ItemNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
