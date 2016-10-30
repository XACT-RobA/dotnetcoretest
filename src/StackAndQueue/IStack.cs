using System;

namespace DotNetCoreTest.StackAndQueue
{
    public interface IStack<T>
    {
        void Push(T data);

        T Pop();

        T Peek();

        bool IsEmpty { get; }
    }
}