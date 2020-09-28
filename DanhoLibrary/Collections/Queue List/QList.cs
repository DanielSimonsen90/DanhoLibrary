using System.Collections;

namespace DanhoLibrary
{
    public class QList<T> : IQueueMethods<T>, IEnumerable
    {
        public IEnumerator GetEnumerator() => Queue.GetEnumerator();
        public readonly MyList<T> Queue = new MyList<T>(2);

        /// <summary> 
        /// Add <paramref name="Item"/> to queue 
        /// </summary>
        /// <param name="Item">Item to add to queue</param>
        public void Enqueue(T Item) => Queue.Add(Item);
        /// <summary> 
        /// Remove 1st item and sorts list 
        /// </summary>
        public void Dequeue() => Queue.Remove(Queue[0]);
        /// <summary> 
        /// Removes specified item from queue 
        /// </summary>
        /// <param name="Item">Item to remove</param>
        public void Dequeue(T Item) => Queue.Remove(Item);
        /// <summary> 
        /// Size of current queue 
        /// </summary>
        public int Size() => Queue.Count;
    } 
}
