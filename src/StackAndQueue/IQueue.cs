using System;

namespace DotNetCoreTest.StackAndQueue
{
    public interface IQueue<T>
    {
        void Enqueue(T data);

        T Dequeue();

        T Peek();

        bool IsEmpty { get; }
    }
}