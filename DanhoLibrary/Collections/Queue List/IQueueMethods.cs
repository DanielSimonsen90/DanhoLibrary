namespace DanhoLibrary.Collections.QueueList
{
    public interface IQueueMethods<T>
    {
        void Enqueue(T data);
        int Size();
        void Dequeue();
    }
}