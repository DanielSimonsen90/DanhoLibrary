using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DanhoLibrary.Collections
{
    public class BasicList<T> : ICollection<T>, IList<T>
    {
        public T this[int index] { get => innerList[index]; set => innerList[index] = value; }
        public virtual T this[string item]
        {
            get => innerList.Find(i => i.ToString() == item);
            set => innerList[innerList.IndexOf(innerList.Find(i => i.ToString() == item))] = value;
        }
        protected readonly List<T> innerList = new List<T>();

        #region Interfaces

        #region ICollection
        public int Count => innerList.Count;
        public bool IsReadOnly => true;

        public void Add(T item) => innerList.Add(item);
        public void Clear() => innerList.Clear();
        public bool Contains(T item) => innerList.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => innerList.CopyTo(array, arrayIndex);
        public bool Remove(T item) => innerList.Remove(item);
        public IEnumerator<T> GetEnumerator() => innerList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => innerList.GetEnumerator();
        #endregion

        #region IList<Channel>
        public int IndexOf(T item) => innerList.IndexOf(item);
        public void Insert(int index, T item) => innerList.Insert(index, item);
        public void RemoveAt(int index) => innerList.RemoveAt(index);
        #endregion

        #endregion

        #region Misc methods
        public T[] ToArray() => innerList.ToArray();
        public List<T> ToList() => (from item in innerList select item).ToList();
        public BasicList<T> AddRange(params T[] arr)
        {
            innerList.AddRange(arr);
            return this;
        }
        public BasicList<T> RemoveRange(params T[] arr)
        {
            foreach (T item in arr)
            {
                if (!innerList.Contains(item)) throw new InvalidOperationException($"List does not contain item \"{item}\"");
                innerList.Remove(item);
            }
            return this;
        }
        public T Find(Predicate<T> match) => innerList.Find(match);
        public void ForEach(Action<T> action) => innerList.ForEach(action);
        #endregion
    }
}
