using System;
using DotNetCoreTest.CircularLinkedList;

namespace DotNetCoreTest.StackAndQueue
{
    public class Queue<T> :IQueue<T>
    {
        private ICircularLinkedList<T> list;

        public Queue()
        {
            list = new CircularLinkedList<T>();
        }

        public void Enqueue(T data)
        {
            list.Append(data);
        }

        public T Dequeue()
        {
            return list.Pop();
        }

        public T Peek()
        {
            return list.Peek();
        }

        public bool IsEmpty
        {
            get
            {
                return list.IsEmpty;
            }
        }
    }
}