using System.Collections;

namespace DanhoLibrary.Collections.QueueList
{
    public class QList<T> : IQueueMethods<T>, IEnumerable
    {
        public IEnumerator GetEnumerator() => Queue.GetEnumerator();
        public readonly MyList<T> Queue = new MyList<T>(2);

        /// <summary> 
        /// Add <paramref name="item"/> to queue 
        /// </summary>
        /// <param name="item">Item to add to queue</param>
        public void Enqueue(T item) => Queue.Add(item);
        /// <summary> 
        /// Remove 1st item and sorts list 
        /// </summary>
        public void Dequeue() => Queue.Remove(Queue[0]);
        /// <summary> 
        /// Removes specified item from queue 
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void Dequeue(T item) => Queue.Remove(item);
        /// <summary> 
        /// Size of current queue 
        /// </summary>
        public int Size() => Queue.Count;
    } 
}
