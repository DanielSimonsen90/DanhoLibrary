namespace DanhoLibrary
{
    public interface IQueueMethods<T>
    {
        void Enqueue(T Data);
        int Size();
        void Dequeue();
    }
}